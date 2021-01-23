    public void Test()
    {
        const int MAX = 1000000;
    
        byte[] arrByte1 = { 11, 22, 33, 44, 55, 66 };
        byte[] arrByte2 = new byte[2];
        Stopwatch sw = new Stopwatch();
    
        // Array.Copy
        sw.Start();
        for (int i = 0; i < MAX; i++)
        {
            Array.Copy(arrByte1, 2, arrByte2, 0, 2);
        }
        sw.Stop();
        Console.WriteLine("Array.Copy: {0}ms", sw.ElapsedMilliseconds);
    
        // Linq
        sw.Start();
        for (int i = 0; i < MAX; i++)
        {
            arrByte2 = arrByte1.Skip(2).Take(2).ToArray();
        }
        sw.Stop();
        Console.WriteLine("Linq: {0}ms", sw.ElapsedMilliseconds);
    }
