    static unsafe void FastCopy(Vector2f[] src, float[] dst, Int32 count)
    {
        if (src == null || dst == null)
        {
            throw new ArgumentException();
        }
        int srcLen = src.Length;
        int dstLen = dst.Length;
        if (srcLen < count ||
            dstLen < count*2)
        {
            throw new ArgumentException();
        }
        // The following fixed statement pins the location of
        // the src and dst objects in memory so that they will
        // not be moved by garbage collection.          
        fixed (Vector2f* pSrc = src)
        {
            fixed (float* pDst = dst)
            {
                byte* ps = (byte*)pSrc;
                byte* pd = (byte*)pDst;
                count *= 8;
                // Loop over the count in blocks of 4 bytes, copying a
                // float (4 bytes) at a time:
                for (int n = 0; n < count/4; n++)
                {
                    *((float*)pd) = *((float*)ps);
                    pd += 4;
                    ps += 4;
                }
            }
        }
    }
