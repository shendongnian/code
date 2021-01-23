    [Test]
    public void Should_BeValid_WhenPropertyIsNullAndOtherPropertyIsNull()
    {
        var attribute = new OptionalIfAttribute("OtherProperty");
        //**********************
        var model = new testModel;//your model that you want to test the validation against
        var context = new ValidationContext(testModel, null, null);
        var result = attribute.IsValid(testModel, context);
    
        Assert.That(result.Count == 0, Is.True); //is valid or Count > 0 not valid 
    }
