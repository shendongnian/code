    private static void UnregisterCarImplementation(
        string make, string model, string serial, string plate)
    {
        foreach (var item in CarFactories)
        {
            if (item.Make == make && item.Model == model
                && item.Serial == serial && item.Plate == plate)
            {
                // take some action
            }
        }
    }
