    [TestMethod]
    public void IsValid_Test()
    {
        var modelObj = new youModelClass {
    		requiredProp = value
    	};
    	var validatorClassObj = new yourValidatorClass();
    
    	var validationResult = validatorClassObj.GetValidationResult( valueToValidate, new ValidationContext( modelObj ) );
    
    	Assert.AreEqual( ValidationResult.Success, validationResult );
    }
