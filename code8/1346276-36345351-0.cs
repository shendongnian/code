    public virtual bool hello(string name, int age)
    {
        string lastName = GetLastName();
    }
    public virtual string GetLastName() 
    {
        return "xxx"; 
    }
    [TestMethod]
    public void MyTest()
    {
        string stringToReturn = "qqq";
        Mock<program> name = new Mock<program>();
        name.CallBase = true;
        name.Setup(x => x.GetLastName()).Returns(stringToReturn );
        var results = name.Object.hello(It.IsAny<string>(), It.IsAny<int>());
        Assert.AreEqual(stringToReturn, results);
    }
