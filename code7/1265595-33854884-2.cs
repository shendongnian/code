    [TestMethod]
    public void ExpressionValidateReturnsNoEntryWhenStringIsNullOrEmpty() 
    {
       var model = new ExpressionModel();
       string emptyString = string.Empty;
       string expectedReturnValue = "There was no entry.";
    
       string expressionReturnValue = model.ExpressionValidate(emptyString);
      
       Assert.AreEqual(expectedReturnValue, expressionReturnValue);
    }
