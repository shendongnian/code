    [TestMethod]
    public void CanDoThings()
    {
        using (_repository=new MyRepository())
        {
            // Arrange            
            var before = _repository.Query().ToList();
    
            var command = new Command();
    
            // Act
            CommandHandler().Handle(command); // Throws error in here
    
            // Assert
            var after = _repository.Query().ToList();
        }
    }
