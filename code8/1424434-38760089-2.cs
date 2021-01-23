    List<int> result = new List<int>();
    result.AddRange(foo);
    result.AddRange(bar);
    result.InsertRange(result.Count, foo);
    result.InsertRange(result.Count, bar);
    
    foo.AddRange(bar); //But was assuming you don't want to change the existing list
