    [Test]
    public void TestCommandLineParameters()
    {
        var code = TestContext.Parameters.Get("Code", "<unknown>");
        var date = TestContext.Parameters.Get("Date", DateTime.MinValue);
        TestContext.WriteLine($"Fetched test parameters {code} and {date}");
    }
