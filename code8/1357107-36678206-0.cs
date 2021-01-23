    [Test]
    public void ItCalls_ModuleRepository_Get_Method() {
        // Arrange
        List<ModuleScreen> queryResult = new List<ModuleScreen>()
        {
            new ModuleScreen()
            {
                Id = 100,
            },
        };
        //Building mapped result from query to compare results later
        List<ModuleScreenContract> expectedMappedResult = queryResult
            .Select(m => new ModuleScreenContract { Id = m.Id })
            .ToList();
        var moduleScreenMock = new Mock<IModuleScreen>();
        moduleScreenMock
            .Setup(c => c.GetAll())
            .Returns(queryResult)
            .Verifiable();
        var administrationRepoMock = new Mock<IAdministrationRepository>();
        administrationRepoMock
            .Setup(c => c.ModuleScreen)
            .Returns(moduleScreenMock.Object)
            .Verifiable();
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(c => c.MapModuleScreenToModuleScreenContracts(queryResult))
            .Returns(expectedMappedResult)
            .Verifiable();
        //NOTE: Not seeing this guy doing anything. What's its purpose
        var dilibApplicationHerlperMock = new Mock<IDiLibApplicationHelper>();
        IDigitalLibraryApplication app = new DigitalLibraryApplication(administrationRepoMock.Object, mapperMock.Object, dilibApplicationHerlperMock.Object);
        //Act (Call the method under test)
        var actualMappedResult = app.GetModuleScreens();
        //Assert
        //Verify that configured methods were actually called. If not, test will fail.
        moduleScreenMock.Verify();
        mapperMock.Verify();
        administrationRepoMock.Verify();
        //there should actually be a result.
        Assert.IsNotNull(actualMappedResult);
        //with items
        CollectionAssert.AllItemsAreNotNull(actualMappedResult.ToList());
        //There lengths should be equal
        Assert.AreEqual(queryResult.Count, actualMappedResult.Count());
        //And there should be a mapped object with the same id (Assumption)
        var expected = queryResult.First().Id;
        var actual = actualMappedResult.First().Id;
        Assert.AreEqual(expected, actual);
    }
