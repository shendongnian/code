    public void Setup()
    {
        var mock = MockRepository.GeneratePartialMock<FakeRepository>();
        mock.nameByIds.Add(1, "test");
    }
