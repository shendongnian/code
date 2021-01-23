    GridObjectCollection gridObjects = new GridObjectCollection();
    gridObjects.GridObjects = new GridObject[]
    {
        new GridObject() { datacol = 1, datarow = 2, datasizex = 3, datasizey = 4 },
        new GridObject() { datacol = 5, datarow = 6, datasizex = 7, datasizey = 8 }
    };
    Console.WriteLine
    (
        JsonConvert.SerializeObject
        (
            gridObjects,
            new JsonSerializerSettings() { Formatting = Formatting.Indented }
        )
    );
