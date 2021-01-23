    [Test]
    public void TaskTest()
    {
        // arrange
        var imei = _fixture.Create<string>();
        _appSettings.Setup(c => c["JctLogInTimeOut"]).Returns("1");
        var message = _fixture.Build<JctRestartViaSmsAttempt>()
            .With(x => x.Imei, imei)
            .Create();
        var sut = _fixture.Create<JctRestartViaSmsAttemptTestRunner>();
        // act
        sut.Execute(message);
        // verify the task was not executed yet
        // ....
        
        // let the test thread sleep and give the task some time to run
        Thread.Sleep(2000);
        // assert
        _queues.Verify(x => x.Publish(It.Is<JctRestartViaSmsValidate>(y => y.Imei == imei)));
    }
