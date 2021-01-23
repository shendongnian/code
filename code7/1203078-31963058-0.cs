log4net.Tests.Stacktrace_Tests.StackTrace_In_PatternLayout > log4net.Tests.Wrapper.Debug
    public class Wrapper
    {
        public void Debug(string message)
        {
            LogManager.GetLogger("test").Debug(message);
        }
    }
    [TestFixture]
    public class Stacktrace_Tests
    {
        [Test]
        public void StackTrace_In_PatternLayout()
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(config)))
            {
                Config.XmlConfigurator.Configure(ms);
            }
            new Wrapper().Debug("Test");
        }
        private const string config = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
    <log4net>
      <appender name=""TestAppender"" type=""log4net.Appender.ConsoleAppender"">
        <layout type=""log4net.Layout.PatternLayout"">
          <conversionPattern value = ""%stacktrace{2}"" />
          </layout>
        </appender>
      <root>
        <level value = ""DEBUG"" />
        <appender-ref ref=""TestAppender"" />
      </root>
    </log4net>";
    }
