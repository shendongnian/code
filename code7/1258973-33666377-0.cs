    static void Main(string[] args)
    {
        var salesMadeHandler = TinyIoCContainer.Current.Resolve<SalesMadeHandler>();
         
        var messageHub = TinyIoCContainer.Current.Resolve<ITinyMessengerHub>();
        messageHub.Publish(new SaleMadeEvent() { Id = Guid.NewGuid(), Total = 100 });
        Console.ReadKey();
    }
