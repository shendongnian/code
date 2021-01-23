    // Test that a date less than today's date is invalid
    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestPastDateIsInvalid()
    {
        DateValTest model = new DateValTest(){ EndDate = DateTime.Today.AddDays(-1) };
        ValidationContext context = new ValidationContext(model);
        MyDateAttribute attribute = new MyDateAttribute();
        attribute.Validate(model.EndDate, context);   
    }
