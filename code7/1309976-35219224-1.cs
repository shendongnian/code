    static void RideCar<T>(T t) where T : ICar, ICanTimeTravel
    {
        t.StartEngine();      // ICar
        t.TravelToYear(1955); // ICanTimeTravel
        t.StopEngine();       // ICar
    }
