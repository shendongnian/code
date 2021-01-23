    void NewThread(QuoteResult result)
    {
        //example for creating the parameters to pass in
        TruckDb db = new TruckDb();
        QuoteData data = new QuoteData();
        const int stackSize = 0x400000;
        var T = new Thread(() => CalculateRates(db, data), stackSize);
        T.Start();
        T.Join();
    }
