    private static void Main(string[] args)
    {
        var dataGeneratorList = new List<IDataGenerator<object>>
        {
            new StringDataGenerator(Name.First, "first", "name"),
            new StringDataGenerator(Name.Last, "last", "name")
    //            But this line doesn't work
    //            new GuidDataGenerator(Guid.NewGuid, "uid", "id")
        };
        var writeProperties = typeof (Employee).GetProperties().Where(p => p.CanWrite);
        foreach (var property in writeProperties)
        {
            foreach (var dataGenerator in dataGeneratorList)
            {
                if (property.PropertyType == dataGenerator.Type)
                {
                    var weigth = dataGenerator.GetWeight(property.Name);
                    var testValue = dataGenerator.Generate();
                }
            }
        }
    }
