    public static byte[] StringToByteArray ( string hex ) {
        byte[] arr = Enumerable.Range(0, hex.Length)
            .Where(x => x % 2 == 0)
            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
            .ToArray();
        Array.Reverse(arr);
        return arr;
    }
