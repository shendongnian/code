    List<YourObject> sList = new List<YourObject>();
    List<YourObject> sResult = new List<YourObject>();
    for (int i = 0; i < sList.Count; i++)
    {
        if (sList[i].Title != "Foo")
            sResult.Add(sList[i]);
    }
