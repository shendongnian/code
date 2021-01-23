    private static void UnregisterCarImplementation(
        string make, string model, string serial, string plate)
    {
        CarFactories.RemoveAll(x => x.Make == make && x.Model == model
                                    && x.Serial == serial && x.Plate == plate);
    }
