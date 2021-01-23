    [Test]
    public void Handle_Initialize_RegistersClassesAToDToReturnInsertCommandHandler()
    {
        var container = ApplicationConfiguration.Initialize();
        var resultA = container.GetInstance<ICommandHandler<ClassA>>();
        var resultB = container.GetInstance<ICommandHandler<ClassB>>();
        var resultC = container.GetInstance<ICommandHandler<ClassC>>();
        var resultD = container.GetInstance<ICommandHandler<ClassD>>();
        Assert.That(resultA.GetType() == typeof(InsertCommandHandler<ClassA>));
        Assert.That(resultB.GetType() == typeof(InsertCommandHandler<ClassB>));
        Assert.That(resultC.GetType() == typeof(InsertCommandHandler<ClassC>));
        Assert.That(resultD.GetType() == typeof(InsertCommandHandler<ClassD>));
    }
