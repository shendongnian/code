    [TestInitialize]
    public void Initialize()
    {
        _instance = Singleton.Instance;
    }
    [Test]
    public void Foo()
    {
       // use _instance.BaseDate 
       // use _instance.BaseEconomy
    }
