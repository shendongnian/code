    [TestMethod]
    public void Calling_GetEndDate_Returns_A_FutureDate()
    {
        // Arrange
        var helper = new StudentHelper(_updateStudentManagerMock.Object, _schedulerHelperMock.Object);
        var now = DateTime.UtcNow;
        // Act
        var result = x.GetEndDate(now.ToShortDateString(),1);
        // Assert
        Assert.Equal(now.AddYears(1).ToString("MM/dd/yyyy"), result);
    }
