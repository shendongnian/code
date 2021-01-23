    var contextMock = new Mock<SampleContext>( );
    contextMock.Setup( c => c.MockCall( ) ).Returns( ( ) => objectResultMock.Object );
    // act
    var repo = new SampleRepository( contextMock.Object );
    var result = repo.SampleSomeCall( );
    // assert
    Assert.IsNotNull(result);
    Assert.AreEqual(shouldBe, result);
