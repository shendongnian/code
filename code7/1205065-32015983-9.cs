    [Test]
    public void Foo_Should_Do_Something()
    {
        var deviceIdProvider = A.Fake<IDeviceIdProvider>();
        A.CallTo(() => deviceIdProvider.GetDeviceId()).Returns("123456");
        var foo = new Foo(deviceIdProvider);
        // test the behavior of Foo...
    }
