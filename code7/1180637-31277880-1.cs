    string[] sampleList = { "a", "b", "c", "d" };
    int splitFactor = 2;
    List<string[]> splitedList = new List<string[]>();
    for (int i = 0; i < sampleList.Length; i += splitFactor)
    {
        //Skip(i) means ignore (i) elements from start of sampleList
        // and start from (i+1)th element.
        //And Take(splitFactor) means give me an array of string to the size of (splitFactor)
        //And finally .ToArray() convert the IEnumerable<string> to string[]
        //Then we simply add it to splittedList
        splitedList.Add(sampleList.Skip(i).Take(splitFactor).ToArray());
    }
