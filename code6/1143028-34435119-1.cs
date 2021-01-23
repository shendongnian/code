    [TestClass]
    public abstract class TestsBase
    {
        public TestContext TestContext { get; set; }
    
        [TestCleanup]
        public void SaveScreenshotOnFailure()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
                return;
    
            var filename = Path.GetRandomFileName() + ".png";
            using (var screenshot = ScreenCapture.CaptureDesktop())
                screenshot.Save(filename, ImageFormat.Png);
    
            TestContext.AddResultFile(filename);
        }
    }
