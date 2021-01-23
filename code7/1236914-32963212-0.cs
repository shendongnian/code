    bool searchwasCalled = false;
    Mock<IEmployeeRepo> repositoryMock = new Mock<IEmployeeRepo>();
    repositoryMock.Setup(r => r.Search(
        It.IsAny<Employee>(), It.IsAny<int[]>(), It.IsAny<bool>(), It.IsAny<int>(),
        It.IsAny<int?>()))
        .Callback(() => searchwasCalled = true);
    
    var mockUnitOfWork = new Mock<IUnitOfWork>();
    mockUnitOfWork.Setup(uow => uow.EmployeeRepository).Returns(repositoryMock.Object);
    
    var sut = new EmployeeService(mockUnitOfWork.Object);
    
    var employeeSearchCriteria = new Employee
    {
        FirstName = "John"
    };
    
    sut.Search(employeeSearchCriteria, null, false, 25, 1);
    
    Assert.IsTrue(searchwasCalled, "Search was not called.");  
          
