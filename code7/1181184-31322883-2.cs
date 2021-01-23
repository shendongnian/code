    [Test]
    public async void MyTest()  // ... The UT can be made async
    {
        var mock = new Mock<IAuthenticationInterface>();
        mock.Setup(e => e.IsAuthorizedAsync(It.IsIn<string>("Foo"), It.IsAny<MyEvent>()))
                .ReturnsAsync(true)  // ... Async
                .Verifiable();
        // async calls can be awaited
        Assert.True(await mock.Object.IsAuthorizedAsync("Foo", null));
    }
