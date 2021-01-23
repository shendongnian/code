    string[] sampleList = { "a", "b", "c", "d" };
    int splitFactor = 2;
    List<string[]> splitedList = new List<string[]>();
    for (int i = 0; i < sampleList.Length; i += splitFactor)
    {
        splitedList.Add(sampleList.Skip(i).Take(splitFactor).ToArray());
    }
