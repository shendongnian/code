    public void Test()
    {
        AutofacLoader.Configure();
        var x = AutofacLoader.Container.Resolve<ITimeConsume>();
    }
