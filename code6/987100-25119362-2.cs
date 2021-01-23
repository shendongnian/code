    var candidates = new List<WeightedItem<string>>
    {
        new WeightedItem<string>("Never", 0),
        new WeightedItem<string>("Rarely", 2),
        new WeightedItem<string>("Sometimes", 10),
        new WeightedItem<string>("Very often", 50),
    };
    for (int i = 0; i < 100; i++)
    {
        Debug.WriteLine(WeightedRandomizer<string>.PickRandom(candidates));
    }
