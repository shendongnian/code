    [SetUp]
    public void SetUp()
    {
        // Arrange
        _service2 = A.Fake<IService2>();
        _service1 = new Service1(_service2);
    }
