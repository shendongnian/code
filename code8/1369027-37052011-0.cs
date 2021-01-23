    [TestCase("27/04/2025", "Holiday cannot start or end on a weekend or non-working day")]
    public void AddHolidays_Exceptions(string date, string expectedMessage)
    {
        Assert.Throws<ArgumentException>(() => ParseDate(date), expectedMessage);
    }
