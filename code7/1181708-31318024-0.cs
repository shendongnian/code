    [Test]
    public void FooTest()
    {
      var foo = new Foo();
      Assert.That(AsyncContext.Run(() => foo.DoSomething()),
          Throws.InstanceOf<Exception>());
    }
