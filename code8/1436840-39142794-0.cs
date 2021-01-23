    IDictionary<int, int> intOccurences = new Dictionary<int, int>();
    List<int> allInputs = new List<int>();
    while (input != string.Empty)
    {
        input = Console.ReadLine();
        allInputs.Add(Convert.ToInt32(input));
    }
    foreach (int i in allInputs)
    {
        int currentCount; //defaults to 0
        intOccurences.TryGetValue(i, out currentCount);
        frequencies[i] = currentCount + 1;
    }
