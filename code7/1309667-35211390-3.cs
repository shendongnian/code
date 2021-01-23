    public object TestMethod()
    {
        var testResult = new {
                             name = "Test",
                             value = 123,
                             nullableProperty = (string) null
                         };
        var f = BindingContext.OutputFormatters.FirstOrDefault(
                    formatter => formatter.GetType() == typeof (JsonOutputFormatter)) as JsonOutputFormatter;
        if (f != null) {
            f.SerializerSettings.Formatting = Formatting.Indented;
            f.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }
        return testResult;
    }
