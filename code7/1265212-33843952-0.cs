    async Task MyTestMethod()
    {
      // Set up the mock object
      var tcs0 = new TaskCompletionSource<int>();
      var tcs1 = new TaskCompletionSource<int>();
      var stub = new Mock<ISimpleManager>();
      stub.Setup(x => x.DoHardWork0Async()).Returns(tcs0.Task);
      stub.Setup(x => x.DoHardWork1Async()).Returns(tcs1.Task);
      var sut = new SimpleClass(stub.Object);
      var task = sut.SimpleMethod();
      Assert.True(sut.InProgress);
      tcs0.SetResult(7);
      Assert.True(sut.InProgress);
      tcs1.SetResult(13);
      await task;
      Assert.False(sut.InProgress);
    }
