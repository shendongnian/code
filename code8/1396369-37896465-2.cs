    [TestMethod]
    public void FluentAssertions_Should_Validate_Collections() {
        //Arrange
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var list = new List<Contract>{
            new Contract() { Id = id1, Name = "A" },
            new Contract() { Id = Guid.NewGuid(), Name = "B"}
        };
        var factoryMock = new Mock<IContractFactory>();
        factoryMock.Setup(m => m.BuildContracts()).Returns(list);
        var factory = factoryMock.Object;
        //Act
        var contracts = factory.BuildContracts();
        //Assert
        contracts.Should()
            .HaveCount(list.Count)
            .And.Contain(c => c.Id == id1 && c.Name == "A")
            .And.NotContain(c => c.Id == id2 && c.Name == "B");
    }
