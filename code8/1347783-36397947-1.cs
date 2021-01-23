    [Fact]
    public void TestThisOut()
    {
       var fakeExternalService = new MockFramework.CreateMock();
       fakeExternalService
           .ShouldDoSomethingWhen(s => s.DoSomeStuff())
           .IsCalled();
       var testThing = new Thing(fakeExternalService);
       testThing.A();
       Assert.That(testThing, Did.Some.Thing());
    }
