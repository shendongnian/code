    [Test]
    public void Should_not_convert_from_prinergy_date_time_sample2()
    {
        void CheckFunction()
        {
            //Arrange
            string testDate = "20121123120122";
            //Act
            testDate.FromPrinergyDateTime();
        }
        //Assert
        Assert.Throws(typeof(Exception), CheckFunction);
    }
