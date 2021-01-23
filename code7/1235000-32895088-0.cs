    static NLog.Logger loggerA = NLog.LogManager.GetLogger("nameA");
    static NLog.Logger loggerB = NLog.LogManager.GetLogger("nameB");
    void Something()
    {
        loggerA.Error("Something");
    }
    void SomethingElse()
    {
        loggerB.Error("SomethingElse");
    }
