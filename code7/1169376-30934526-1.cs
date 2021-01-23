    [Fact]
    public void Test1()
    {
        //Arrange
        var document = new TestableDocument(DocumentState.Confirmed));
        //Act
        document.Close();
        //Assert
        Assert.Equal(DocumentState.Closed, document.State); 
    }
