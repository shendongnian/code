	[TestMethod]
	public void returngetId_Always1()
	{
	    // ... Build up our mock object
	    _mock.Setup(x => x.getId(It.IsAny<int>())).Returns(1);
	    Assert.AreEqual(1, _mock.Object.getId("foo"));
	    Assert.AreEqual(1, _mock.Object.getId("bar"));
	}
