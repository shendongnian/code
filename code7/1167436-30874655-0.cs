    var ad = AppDomain.CreateDomain("Sandbox");
    ad.UnhandledException += (o, e) =>
    {
        Console.WriteLine("Who Cares");
    };
    ad.Load("TestLibrary.TestLibrary");
    ad.DoCallBack(() =>
    {
         TestLibrary lib = new TestLibrary();
         lib.DoWork();
    });
