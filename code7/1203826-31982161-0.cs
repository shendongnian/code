    private static byte[] ConvertStringsToBytes(List<string> list)
    {
        int totalSize = list.Sum(x => Encoding.UTF8.GetByteCount(x));
        byte[] buffer = new byte[totalSize];
        int ix = 0;
        foreach (string str in list)
        {
            ix += Encoding.UTF8.GetBytes(str, 0, str.Length, buffer, ix);
        }
        return buffer;
    }
