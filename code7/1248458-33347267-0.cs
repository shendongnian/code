    public class PageTestBase
    {
        protected IWebDriver Driver;
        protected void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var screenshot = Driver.TakeScreenshot();
                var filePath = "<some appropriate file path goes here>";
                screenshot.SaveAsFile(filePath, ImageFormat.Png);
                // This would be a good place to log the exception message and
                // save together with the screenshot
                throw;
            }
        }
    }
