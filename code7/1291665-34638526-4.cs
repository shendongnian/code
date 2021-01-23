    var someMock = new Mock<ISomeEntity>();
    
    someMock.SetupGet(x => x.Id).Returns(12345678);
    someMock.SetupGet(x => x.Name).Returns(It.IsIn(someList));
    var result = somethingelse.Act(someMock.Obect);
