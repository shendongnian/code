    [TestMethod]
    public void List_StudentListViewModelIsValid_ViewModelIsPopulated()
    {
        // Arrange
        var students = Builder<Student>().CreateListOfSize(10).Build();
        var repositoryMock = new Mock<StudentRepository>();
        
        repositoryMock.Setup(r => r.GetAll()).Returns(students);
    
        var testInstance = new StudentListViewModel(repositoryMock.Object); // DIP
    
        // Act
        testInstance.List()
    
        // ASsert
        // Check your values etc
    }
