    // arrange
    IConsumeContext<mymessage> contextMock = new Mock<IConsumeContext<mymessage>>();
    contextMock.Setup(c => c.Message).Returns("Not_A_Null_Value");
    
    var obj = new UberConsumer();
    obj.Condition1 = true;
    
    // obj.Condition2 doesn't really matter.. so you could run a combination of the tests, 
    // one for condition2 = true and another for false.
    // setup callback for the mockable LogMe method and capture the string parameter value
       // string capturedStringValue = null
       // mockLogMeObj.Setup(l => l.LogMe(It.IsAny<string>()).Callback(val => { capturedStringValue = val} );
       // you could also verify the call count
    // act
    uberConsume.Consume(contextMock.Object);
    // assert
    // assert that the captured parameter of Logme was "condition1 is true"
    Assert.Equals("condition1 is true", capturedStringValue);
    // assert that the LogMe was called only once.
    //  mockLogMeObj.Setup(l => l.LogMe(It.IsAny<string>()).Verify(Times.Once());
