    [TestMethod]
    public void IsSingleton()
    {
        Assert.AreSame(Singleton.Instance, Singleton.Instance);
    }
