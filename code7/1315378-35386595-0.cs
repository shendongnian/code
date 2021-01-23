    var mockS = new Mock<IServiceLocator>();
            ServiceLocator.SetLocatorProvider(() => mockS.Object);
    
    var factoryMock = new Mock<IObjectFactoryMethod<IAddress>>(MockBehavior.Strict);
            factoryMock.Setup(x => x.Create(null)).Returns(new Mock<IAddress>());
    
            mockS.Setup(x => x.GetInstance<IObjectFactoryMethod<IAddress>>()).Returns(factoryMock);
    
            
    
            var factory = ServiceLocator.Current.GetInstance<IObjectFactoryMethod<IAddress>>();
    
            // testing - factory returns null
            var address = factory.Create(null); // address is null
