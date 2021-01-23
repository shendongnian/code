    public static unsafe void Clear(ref char s)
    {
        fixed (char* n = &s)
        {
            *n = '\0';
        }
    }
