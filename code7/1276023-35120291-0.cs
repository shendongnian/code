    public interface IThing
    {
        string DoIt<T>(T it);
    }
    public class Subject
    {
        ...
        public string Execute()
        {
            var param = new
            {
                Foo = "bar",
                Baz = 23
            };
            return _thing.DoIt(param);
        }
    }
    [Test]
    public void Test()
    {
        var mockThing = new Mock<IThing>();
        mockThing.Setup(t => t.DoIt(It.IsAny<object>()))
            .Returns("expectedResult");
        var subject = new Subject(mockThing.Object);
        var result = subject.Execute();
        Assert.That(result, Is.EqualTo("expectedResult"));
    }
