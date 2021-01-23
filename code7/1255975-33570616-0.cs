    //using Dictionary<int, List<string>>
    for(int i in ...)
    {
       if (!dict.ContainsKey(i))
          dict[i] = new List<string>();
       dict[i].Add("hello");
    }
