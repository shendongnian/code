    List<int> current = new List<int> { Int32.MaxValue };
    int[] best = new int[0];
    int n = int.Parse(Console.ReadLine());   
    
    for (int i = 0; i < n; i++)
    {
        var read = int.Parse(Console.ReadLine());
        if (read < current[current.Count - 1])
        {
            if (current.Count > best.Length) best = current.ToArray();
            current.Clear();
        }
        current.Add(read);
    }
