    // Arrange
    EmailEventArgs argsInEvent = null;
    
    var repository = A.Fake<IRepository>();
    
    A.CallTo(repository).Where(w => w.Method.Name == "OnSaveRequest")
        .Invokes(i => argsInEvent = i.GetArgument<EmailEventArgs>(0));
    // Act
    repository.SaveSetup(…);
    
    // Assert
    A.CallTo(repository).Where(w => w.Method.Name == "OnSaveRequest")
        .MustHaveHappened(Repeated.Exactly.Once);
    // and maybe do something with argsInEvent
