    public static void SaveScreenshot(RemoteWebDriver driver)
    {
        try
        {
            using(var screenshot = driver.TakeScreenshot())
            {
                screenshot.SaveAsFile(DateTime.Now.Ticks + ".jpg", ImageFormat.Jpeg);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
