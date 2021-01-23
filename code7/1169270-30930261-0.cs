    class Program { static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Url = @"file:///C:/users/user/documents/visual%20studio%202012/Projects/LearnSelenium_Xpath/LearnSelenium_Xpath/TestPage.html";
        try
        {
            var radiobutton = driver.FindElements(By.Name("Color"))[0]; -->Exception
            radiobutton.Click();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message(), "Radio button not found error);
        }
    }
