    [Test]
    public void Should_not_convert_from_prinergy_date_time_sample2()
    {
        //Arrange
        string testDate = "20121123120122";
    
        //Act
        ActualValueDelegate<object> testDelegate = () => testDate.FromPrinergyDateTime();
        //Assert
        Assert.That(testDelegate, Throws.TypeOf<FormatException>());
    }
