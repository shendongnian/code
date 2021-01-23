    for (int i = 0; i < bytes.Length; i += 16)
    {
        int takeSize = Math.Min(16, bytes.Length - i);
        byte[] line = new byte[takeSize];
        Array.Copy(bytes, i, line, 0, takeSize);
        Console.WriteLine(BitConverter.ToString(line));
    }
