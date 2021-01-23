    [Test]
    public void Test()
    {
        dynamic param = null;
        var mockThing = new Mock<IThing>();
        mockThing.Setup(t => t.DoIt(It.IsAny<object>()))
            .Callback<object>(p => param = p);
        var subject = new Subject(mockThing.Object);
        subject.Execute();
        Assert.That(param.Foo, Is.EqualTo("bar"));
        Assert.That(param.Baz, Is.EqualTo(23));
    }
