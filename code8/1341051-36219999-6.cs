    [Fact]
    public void it_should_update_the_last_accessed_timestamp_on_an_entry()
    {
        // Arrange
        MockDateTime mockDateTime = new MockDateTime(new DateTime 2000, 1, 1);
        var service = this.CreateClassUnderTest(mockDateTime);
    
        // Act
        service.UpdateLastAccessedTimestamp(this._testEntry); 
    
        // Assert
        Assert.Equal(mockDateTime.Now, this._testEntry.LastAccessedOn);
    }   
