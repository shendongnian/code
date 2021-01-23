    [Test]
	public void GetDelegate_WhenCalledWithIsValidTrue_ReturnsDelegateA()
	{
		// Arrange
		Mock<IService1> service1Mock = new Mock<IService1>();
		Mock<IService2> service2Mock = new Mock<IService2>();
		string expectedResultA = "A";
		string expectedResultB = "B";
		service1Mock.Setup(s => s.A(It.IsAny<int>())).Returns(expectedResultA);
		service2Mock.Setup(s => s.B(It.IsAny<int>())).Returns(expectedResultB);
		var _sut = new AFactory(service1Mock.Object, service2Mock.Object);
		// Act
		Func<int, string> delegateObj = _sut.GetDelegate(true);
		// Assert
		string result = delegateObj(0);
		Assert.AreEqual<string>(expectedResultA, result);
	}
