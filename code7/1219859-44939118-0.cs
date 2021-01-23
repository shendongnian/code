    /// <summary> Convert byte array to "thin string" </summary>
    public static unsafe String ToThinString(this byte[] src)
    {
        int c;
        var ret = String.Empty;
        if ((c = src.Length) > 0)
            fixed (char* dst = (ret = new String('\0', c)))
                do
                    dst[--c] = (char)src[c];  // fill new String by in-situ mutation
                while (c > 0);
        return ret;
    }
