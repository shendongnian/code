    [Theory]
    [InlineData("MyFileLogger")]
    [InlineData("MyDbLogger")]
    [InlineData("MyDbLogger2")]
    [InlineData("MyConsoleLogger")]
    [InlineData("MyNullLogger")]
    [InlineData("MyMultiplexingLogger")]
    [InlineData("MyFailoverLogger")]
    public void JSONConfigurationFileParser_Should_Return_A_Logger_Given_A_Name(string expectedLoggerName)
        {
            // ARRANGE
            var currentFilePath = Environment.CurrentDirectory + @"\MyCompanyConfiguration.json";
            var jsonString = File.ReadAllText(currentFilePath);
            var jsonConfigurationFileParser = new JSONConfigurationFileParser(jsonString);
    
            // ACT
            var actualLoggers = jsonConfigurationFileParser.DeserializeLogger();
    
            // ASSERT
            Assert.True(actualLoggers.Any(x=> x.Name == expectedLoggerName));
        }
