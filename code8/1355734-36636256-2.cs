    [TestMethod]
    public void UOW_Should_Be_Disposed() {
        //Assert
        var fake_entities = Enumerable.Range(1, 10).Select(i => new MyEntity());
        var mockRepository = new Mock<IMyEntityRepository>();
        mockRepository.Setup(m => m.Get()).Returns(fake_entities);
        var mockUOW = new Mock<IUnitOfWork>();
        mockUOW.Setup(m => m.MyEntityRepository).Returns(mockRepository.Object);
        var mockFactory = new Mock<IUnitOfWorkFactory>();
        mockFactory.Setup(m => m.Create()).Returns(mockUOW.Object);
        //Act
        var sut = new MyDependentClass(mockFactory.Object);
        var output = sut.MyMethod().ToList();
        //Assert
        output.Should().NotBeNull();
        output.Should().HaveCount(10);
        output.Should().ContainItemsAssignableTo<MyClass>();
        mockUOW.Verify(m => m.Dispose());
    }
