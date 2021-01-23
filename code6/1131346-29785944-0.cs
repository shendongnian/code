    public interface IFoo {
        void SayHello(string to);
    }
    [Test]
    public void SayHello() {
        var counter = 0;
        var foo = Substitute.For<IFoo>();
        foo.When(x => x.SayHello("World"))
            .Do(x => counter++);
 
        foo.SayHello("World");
        foo.SayHello("World");
        Assert.AreEqual(2, counter);
    }
