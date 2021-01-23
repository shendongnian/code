    var myCommResult = new PostAlertModel();
    _mockEestCommunicationService
        .Setup(x => x.PerformPost<string, PostAlertModel>(It.IsAny<string>(), It.IsAny<PostAlertModel>(), out apiErrors)
        .Returns(myCommResult);
    
    var response = _systemUnderTest.CreateTrip(consumerNumber, trip, out apiErrors);
    
    Assert.AreSame(myCommResult, response);
