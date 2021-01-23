    file
        //ReadLines is non-greedy equiv of ReadAllLines
        //best to do this on a single thread...
        .SelectMany(i => File.ReadLines(i))
        //now go parallel.
        .AsParallel()
        .SelectMany(line => line.Split(new[] { ' ', ',', '.', '?', '!', },
                            StringSplitOptions.RemoveEmptyEntries))                   
        .GroupBy(word => word)
        .ToDictionary(g => g.Key, g => g.Count());
