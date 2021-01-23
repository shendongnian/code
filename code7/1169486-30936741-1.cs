    List<YourObject> List = new List<YourObject>();
    List<YourObject> Result = new List<YourObject>();
    for (int i = 0; i < List.Count; i++)
    {
        if (List[i].Title != "Foo")
            Result.Add(List[i]);
    }
