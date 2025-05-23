using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.ImgHash;

/// <inheritdoc />
/// <summary>
/// Image hash based on Radon transform.
/// </summary>
public class RadialVarianceHash : ImgHashBase
{
    /// <summary>
    /// cv::Ptr&lt;T&gt;
    /// </summary>
    private Ptr? ptrObj;

    /// <summary>
    /// 
    /// </summary>
    protected RadialVarianceHash(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Create BlockMeanHash object
    /// </summary>
    /// <param name="sigma">Gaussian kernel standard deviation</param>
    /// <param name="numOfAngleLine">The number of angles to consider</param>
    /// <returns></returns>
    public static RadialVarianceHash Create(double sigma = 1, int numOfAngleLine = 180)
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_RadialVarianceHash_create(sigma, numOfAngleLine, out var p));
        return new RadialVarianceHash(p);
    }
        
    /// <inheritdoc />
    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    /// <summary>
    /// Gaussian kernel standard deviation
    /// </summary>
    public double Sigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_RadialVarianceHash_getSigma(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_RadialVarianceHash_setSigma(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The number of angles to consider
    /// </summary>
    public int NumOfAngleLine
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_RadialVarianceHash_getNumOfAngleLine(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_RadialVarianceHash_setNumOfAngleLine(ptr, value));
            GC.KeepAlive(this);
        }
    }
        
    // ReSharper disable once RedundantOverriddenMember
    /// <inheritdoc />
    /// <summary>
    /// Computes average hash value of the input image
    /// </summary>
    /// <param name="inputArr">input image want to compute hash value, type should be CV_8UC4, CV_8UC3, CV_8UC1.</param>
    /// <param name="outputArr">Hash value of input</param>
    /// <returns></returns>
    public override void Compute(InputArray inputArr, OutputArray outputArr)
    {
        base.Compute(inputArr, outputArr);
    }

    internal class Ptr(IntPtr ptr) : OpenCvSharp.Ptr(ptr)
    {
        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.img_hash_Ptr_RadialVarianceHash_get(ptr, out var ret));
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.img_hash_Ptr_RadialVarianceHash_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
