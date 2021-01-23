    [TestMethod]
    /// <summary>Test stub for MonthsAliveInPlanet(Int32, Int32, Int32)</summary>
    public void MonthsAliveInPlanetTestShouldFailWithZeroMonthsInYear()
    {
        //Arrange
        IView view = new MyView();
        Model target = new Model();
        Controller ctrl = new Controller(view, target);                        
        int yearBorn = 0;
        int yearInTime = 0;
        int monthsInPlanetsYear = 0;
    
        //Act
        int result = target.MonthsAliveInPlanet(yearBorn, yearInTime, monthsInPlanetsYear);
    
        //Assert
        Assert.AreEqual("Attempted to divide by zero.",((MyView)view).ErrorMessage);
    }
