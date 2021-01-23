    int typesOfCounts = 6;
    IEnumerable<Fruit> theCounter = fruitList.Where(x => theFruitIDs.Contains(x.FruitID));
    Dictionary<string, int> myCounterMode = new Dictionary<string, int>();
    for (var i = 1; i < typesOfCounts + 1; i++)
    {
        string counterType = "CountTypeX";
        counterType = counterType.Replace("X", i.ToString());
        myCounterMode.Add(counterType, theCounter.Count(x => x.FruitType == i));
    }
    return myCounterMode;
