    /// <summary> Convert "thin string" to byte array </summary>
    public static unsafe byte[] ToByteArr(this String src)
    {
        int c;
        byte[] ret = null;
        if ((c = src.Length) > 0)
            fixed (byte* dst = (ret = new byte[c]))
                do
                    dst[--c] = (byte)src[c];
                while (c > 0);
        return ret ?? new byte[0];
    }
