        var serviceFactoryMock = new Mock<IServiceProviderFactory>();
        var wserviceTest = new Mock<IInterfaceAssignmentService>();
        var wassagnementTest = new Mock<InterfaceAssignment>();
        serviceFactoryMock.Setup(x=>x.CreateInterfaceAssignmentService())
                          .Returns(wserviceTest.Object);
        wserviceTest.Setup(x=>x.CreateInterfaceAssignmentService())
                    .Returns(wassagnementTest.Object);
        wassagnementTest.Setup(x=>x.LoadAssignmentGroup(It.IsAny<string>()))
                    .Returns(cannedInterfaceAssignmentResponse);
