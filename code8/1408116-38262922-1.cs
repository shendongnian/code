    [TestCase("PassingCondition", Result = "PassingCondition")]
    [TestCase("NotPassingCondition", Result = string.empty)]
    public bool TheTest(string y) {
        return MethodToTest(y);
    }
