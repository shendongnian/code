    public static List<T> CloneInto<T>(List<T> source, List<T> destination)
    {
        if (destination.Capacity < source.Capacity)
        {
            /* Increase capacity in destination */
            destination.Capacity = source.Capacity;
        }
        /* Direct copy of items within the limit of both counts */
        for (var i = 0; i < source.Count && i < destination.Count; i++)
        {
            destination[i] = source[i];
        }
        if (source.Count > destination.Count)
        {
            /* Append any extra items from source */
            for (var i = destination.Count; i < source.Count; i++)
            {
                destination.Add(source[i]);
            }
        }
        else if (source.Count < destination.Count)
        {
            /* Trim off any extra items from destination */
            while (destination.Count > source.Count)
            {
                destination.RemoveAt(destination.Count - 1);
            }
        }
        return destination;
    }
    static void Main(string[] args)
    {
        List<string> list1 = new List<string>();
        List<string> list2 = new List<string>();
        for (int i = 0; i < 100000; i++)
        {
            list1.Add(Guid.NewGuid().ToString());                
        }
        Stopwatch s = new Stopwatch();
        s.Start();
        CloneInto(list1, list2);
        s.Stop();
        Console.WriteLine("Your Method: " + s.Elapsed.Ticks);
        s.Reset();
        s.Start();
        list2 = list1.ToList();
        s.Stop();
        Console.WriteLine("ToList() Method: " + s.Elapsed.Ticks);
        Console.ReadKey();
