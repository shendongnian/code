    static void Main(string[] args)
    {
        IUnityContainer container = new UnityContainer();
        container.RegisterType<IPlatformFactory, WebPlatformFactory>();
        var logic = container.Resolve<BusinessLogic>();
        logic.DoSomethingWithData();
        string useDataInUI = logic.GetSomeData();
        Console.WriteLine("UI " + useDataInUI);
        Console.ReadKey();
    }
