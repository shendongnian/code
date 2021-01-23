    private static void UnregisterCarImplementation(
        string make, string model, string serial, string plate)
    {
        var factory =
            CarFactories.SingleOrDefault(x => x.Make == make && x.Model == model
                                              && x.Serial == serial && x.Plate == plate);
        if (factory != null)
            Carfactories.Remove(factory);
    }
