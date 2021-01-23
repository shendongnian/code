    using OpenQA.Selenium;
    using System.Drawing.Imaging;
    ...
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        {
    	    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
    	    screenshot.SaveAsFile(@"C:\TEMP\Screenshot.jpg", ImageFormat.Jpeg);
        }
    }
