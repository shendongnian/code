    var mockThing = new Mock<IThing>();
    _mockThingFactory.Setup(f=> f.MakeEmptyThing()).Returns(mockThing.Object);
    classUnderTest =  new SomeClass(_mockThingFactory.Object);  
    classUnderTest.CreateThing(1,2,3);
    mockThing.Verify(....)
    
