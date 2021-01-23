    public object TestMethod()
    {
        var testResult = new {
                             name = "Test",
                             value = 123,
                             nullableProperty = (string) null
                         };
        return testResult;
    }
