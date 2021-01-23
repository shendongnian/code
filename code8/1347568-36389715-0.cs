	var mockA = new Mock<InterfaceA>();
	var mockB = new Mock<InterfaceB>();
	
	mockA.Setup(i => i.CreateObjectOfInterfaceB()).Returns(mockB.Object);
	
	// Do your test
	
	mockA.Verify(i => i.CreateObjectOfInterfaceB(), Times.Once);
	mockB.Verify(i => i.DoSth(), Times.Once);
