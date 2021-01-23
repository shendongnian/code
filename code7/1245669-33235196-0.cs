    [Test]
    public void TestDoSomethigMethod()
    {
        var repository = Substitute.For<IGenericRepository<Item>>();
        // Here you set up repository expectations
        DerivedService tempService = new DerivedService(repository);
        var response = tempService.DoSomething();
        // Here you assert the response
    }
