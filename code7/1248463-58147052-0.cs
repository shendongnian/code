public TestContext TestContext { get; set; }
[TestCleanup]
public void TestCleanup()
{
  if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
  {
    var screenshotPath = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.png";
    MyDriverInstance.TakeScreenshot().SaveAsFile(screenshotPath);
    TestContext.AddResultFile(screenshotPath);
  }
}
