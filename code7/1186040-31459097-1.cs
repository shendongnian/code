    lock (list)
    {
        // VERY LONG OPERATION HERE
        List<int> tmp = list.ToList();  //Exception here!
        Console.WriteLine(list.Count);
    }
