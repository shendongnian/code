    public void Test()
    {
        const int MAX = 1000000;
    
        int[] arrByte1 = Enumerable.Range(0, 1000).ToArray();
        int[] arrByte2 = new int[500];
        Stopwatch sw = new Stopwatch();
    
        // Array.Copy
        sw.Start();
        for (int i = 0; i < MAX; i++)
        {
            Array.Copy(arrByte1, 500, arrByte2, 0, 500);
        }
        sw.Stop();
        Console.WriteLine("Array.Copy: {0}ms", sw.ElapsedMilliseconds);
    
        // Linq
        sw.Restart();
        for (int i = 0; i < MAX; i++)
        {
            arrByte2 = arrByte1.Skip(500).Take(500).ToArray();
        }
        sw.Stop();
        Console.WriteLine("Linq: {0}ms", sw.ElapsedMilliseconds);
    }
