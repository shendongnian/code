    class FruitCollection
    {
        string[] Fruits { get; set; }
    }
    var fruitColls = JsonConvert.DeserializeObject<FruitCollection>(json);
    var mostCommon = fruitColls
        .SelectMany(fc => fc.Fruits)
        .GroupBy(f => f)
        .OrderByDescending(g => g.Count())
        .First()
        .Key;
