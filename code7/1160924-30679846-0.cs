    static void Output(string s)
    {
        Console.WriteLine(s);
        sw.WriteLine(s);
    }
    static void Output(byte[] bytes)
    {
        int dataLength = bytes.Length;
        List<byte> modified = new List<byte>();
        for (int i = 0; i < dataLength; i++)
        {
            if (bytes[i] == 0xBC && (i < dataLength - 1) && bytes[i + 1] == 0x25)
            {
                modified.Add(0x1F);
                i++;
            }
            else
            {
                modified.Add(bytes[i]);
            }
        }
        byte[] data = modified.ToArray();
        Console.WriteLine(Encoding.UTF8.GetString(bytes));      // Use this or the next line
        // Console.WriteLine(Encoding.UTF8.GetString(data));
        sw.BaseStream.Write(data, 0, data.Length);
        sw.WriteLine();
    }
