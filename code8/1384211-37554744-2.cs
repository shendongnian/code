    public void WhenPerformingCalculation_ThenResultIsCorrect() {
        // imagine calculator with two numbers and a sign
        var testResult =
        modelUnderTest.LeftSideNumber.SetValue(3) // set first number
                      .Operator.SetValue("*") // set sign
                      .RightSideNumber.SetValue(10) // set right number
                      .Evaluate.Click() // press evaluate button
                      .Result; // get the result
        Assert.AreEqual(testResult, 30);
    }
