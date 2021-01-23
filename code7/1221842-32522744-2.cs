    Dictionary<int, List<Sample>> FinalList = new Dictionary<int, List<Sample>>();
    Sample NewItem = new Sample()
    {
        IdOfSample = 12345,
        SampleName = "Some name"
    };
    List<Sample> list;
    if (!FinalList.TryGetValue(NewItem.IdOfSample, out list))
    {
        list = new List<Sample>();
        FinalList.Add(NewItem.IdOfSample, list);
    }
    list.Add(NewItem);
