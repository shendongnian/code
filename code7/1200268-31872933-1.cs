    [TestMethod()]
    [HostType("Moles")]
    public void ShouldBeAbleToTestStaticMethod()
    {
        var instance = new SomeInstanceClass();
        var testValue = instance.SomeInstanceMethod("Some test string");
        SomeStaticClass.SomeStaticMethod = (s) => "Moled you! " + s;
        Assert.That(testValue, Is.EqualTo("Moled you! Some test string"); // sorry, this has code smell, lol
    }
