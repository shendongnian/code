    IEnumerable<Fruit> theCounter = fruitList.Where(x => theFruitIDs.Contains(x.FruitID));
    Dictionary<string, int> myCounterMode = new Dictionary<string, int>();
    for (int i = 0; i < theCounter.Count(); i++)
    {
        string counterType = "CountTypeX";
        counterType = counterType.Replace("X", (i + 1).ToString());
        myCounterMode.Add(counterType, theCounter.Count(x => x.FruitType == (i + 1)));
    }
    return myCounterMode;
