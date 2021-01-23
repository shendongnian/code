    _subsiteRepository = new Mock<IRepository<Subsite>>();
    _unitOfWork = new Mock<IUnitOfWork<PlatformContext>>();
    
    // Arrange
    var fakeSubsites = new List<Subsite>
    {
        new Subsite {IDSubsite = new Guid(), Title = "Subsite One"}
    }.AsQueryable();
    
    _unitOfWork.Setup(x => x.GetRepository<Subsite>()).Returns(_subsiteRepository.Object);
    _unitOfWork.Setup(x => x.GetRepository<Subsite>().GetAll()).Returns(fakeSubsites);
    
    // Act
    _platformService = new PlatformService(_unitOfWork.Object);
    var subsites = await _platformService.GetSubsites(null, null);
    
    // Assert
    Assert.NotNull(subsites);
