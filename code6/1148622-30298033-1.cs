    [SetUp]
    public void SetUp()
    {
        clientsRepository = Substitute.For<IRepository<ContactIndex>>();
        _baseController = new ClientsController(clientsRepository);
                
        Helpers.SetupControllerForTests(_baseController);
    }
