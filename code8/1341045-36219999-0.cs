    [Fact]
    public void it_should_update_the_last_accessed_timestamp_on_an_entry()
    {
        // Arrange
        var service = this.CreateClassUnderTest();
    
        var expectedTimestamp = SystemTime.Now();
        SystemTime.Now = () => expectedTimestamp;
    
        // Act
        service.UpdateLastAccessedTimestamp(this._testEntry); 
    
        // Assert
        Assert.Equal(expectedTimestamp, this._testEntry.LastAccessedOn);
    }   
    
    public void UpdateLastAccessedTimestamp(Entry entry)
    {
        entry.LastAccessedOn = SystemTime.Now();
        this._unitOfWork.Entries.Update(entry);
        this._unitOfWork.Save();
    }
