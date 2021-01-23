    public static long LongFromBytes(byte[] bytes)
    {
        // This uses little-endian format. If you're expecting bigendian, you
        // would need to reverse the order of the bytes before doing this.
        return BitConverter.ToInt64(bytes.Concat(new byte[8-bytes.Length]).ToArray(), 0);
    }
