    public class MyTestThing : IMyThing
    {
        public virtual int Id { get; }
        
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
    [TestCase(55)]
    public void Can_mock_equals_method(int newId)
    {
        var mockThing = new Mock<MyTestThing>();
        mockThing.Setup(t => t.Id).Returns(newId);
        mockThing.Setup(t => t.Equals(It.IsAny<object>()))
            .Returns<object>(t => (t as IMyThing)?.Id == newId);
        Assert.That(mockThing.Object.Equals(new MyRealThing(newId)));
    }
