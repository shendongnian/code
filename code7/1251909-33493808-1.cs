	var mockDataManager = new Mock<DataManager>();
	mockDataManager.Setup(m => m.GetMyDataObject(It.IsAny<UserObj>(), It.IsAny<Guid>()));
	var sut = new SUT(mockDataManager.Object);
	sut.Method(new UserObj(), Guid.Empty);
	
	mockDataManager.VerifyAll();
