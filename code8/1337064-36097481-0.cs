    private void ExecuteValidation(object model, string exceptionMessage)
    {
        try
        {
            var contex = new ValidationContext(model);
            Validator.ValidateObject(model, contex);
            Assert.IsTrue(true);
        }
        catch (ValidationException exc)
        {
            Assert.AreEqual(exceptionMessage, exc.Message);
            return;
        }
    }
