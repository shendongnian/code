        List<int> items = new List<int>();   
    
        for (int i = 1; i < 100; i++)
        {
            items.Add(i);
        }
        Stopwatch s = new Stopwatch();
        s.Start();
        int count = 0;
        foreach (var list in GetCombinations(items, 4))
        {
            count++;
        }
        s.Stop();
        Console.WriteLine(count);
        Console.WriteLine(s.ElapsedMilliseconds);
        Console.ReadLine();
