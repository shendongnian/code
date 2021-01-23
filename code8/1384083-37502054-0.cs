    static void UpdateNthLong(MemoryStream ms, long idx, long newValue)
    {
        var currPos = ms.Position;
        try
        {
            var offset = sizeof(long) * idx;
            ms.Position = offset;
            var bw = new BinaryWriter(ms);
            bw.Write(newValue);
        }
        finally { ms.Position = currPos; }
    }
    static void ShowByteArray(byte[] array)
    {
        Console.WriteLine("Size: {0}", array.Length);
        for(int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("{0} => {1}", i, array[i]);
        }
    }
    static void Main(string[] args)
    {
        using (var ms = new MemoryStream())
        {
            var bw = new BinaryWriter(ms);
            bw.Write(1L); // 0-th
            bw.Write(2L); // 1-th
            bw.Write(3L); // 2-th
            bw.Write(4L); // 3-th
            var bytes = ms.ToArray();
    
            Console.WriteLine("Before update:");
            ShowByteArray(bytes);
            // Update 0-th
            UpdateNthLong(ms, 0, 0xFFFFFFFFFFFFFF);
            // Update 3-th
            UpdateNthLong(ms, 3, 0xBBBBBBBBBBBBBBB);
    
            bytes = ms.ToArray();
            Console.WriteLine("After update:");
            ShowByteArray(bytes);
        }
    }
