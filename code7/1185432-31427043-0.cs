    private static Model PopulateModel(IEnumerable<string> rawData)
    {
        return new Model
        {
            ID = int.Parse(rawData[0]),
            Date = DateTime.Parse(rawData[1]),
            ...
        };
    }
