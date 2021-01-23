    // Arrange
    var data = new RateManagement
    {
        TotalBedtimeHours = TimeSpan.FromHours(3),
        TotalHoursBeforeBedtime = TimeSpan.FromHours(2),
        TotalOvertimeHours = TimeSpan.FromHours(4)
    };
    var timeData = new TimeManagement { // your properties };
    // Act
    var business = new BabysitterBusiness(timeData, data);
    var result = business.CalculatePaymentDue();
    // Assert
    Assert.AreEqual(result, 16M);
