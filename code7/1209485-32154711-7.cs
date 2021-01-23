    public unsafe T ConvertTo<T>(byte[] bytes, int offset)
        where T: struct // not needed to work, just to eliminate some errors
    {
        fixed(byte* ptr = bytes)
        {
             return GenericPointerHelper.Read<T>(ptr + offset);
        }
    }
