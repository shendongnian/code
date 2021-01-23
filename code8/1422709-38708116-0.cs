    [TestMethod]
    public void GetHoliday_GetHolidayByName()
    {
        // Arrange
        string name = "Spain";
        HolidaysController controller = new HolidaysController();
        // Act
        IQueryable<Holiday> actionResult = controller.GetHolidayByName(name);
        //Assert
        Assert.IsNotNull(actionResult);
        Assert.IsTrue(actionResult.All(n => string.Equals(n.Name, name));
    }
