    [TestMethod]
    public void TestMethod1()
    {
        var i = new Moq.Mock<IChairType>();
        i.Setup(x => x.A()).Returns("A Faked String");
        var fakedObject = i.Object;
        var result = fakedObject.A();
        Console.WriteLine(result);  // A Faked String
    }
