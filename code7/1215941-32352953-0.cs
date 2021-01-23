    List<string> result= new List<string>();
    while(parent.Any()) {
        result.Add(String.Join("", parent.Take(20).ToArray());
        parent = parent.Skip(20);
    }
