     FirefoxDriver driver = null;
        private WebDriverWait wait;
        // Use this function to take screen short of an element.  
    public static Bitmap GetElementScreenShort(IWebDriver driver, IWebElement element)
    {
        Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
        var img = Image.FromStream(new MemoryStream(sc.AsByteArray)) as Bitmap;
        return img.Clone(new Rectangle(element.Location, element.Size), img.PixelFormat);
    }
     //testing function
        public void GetIPLocation(string IPAddress)
        {
            try
            {
                if (driver == null)
                    driver = new FirefoxDriver();
                if (driver.Title != "IP Location Finder - Geolocation")
                    driver.Navigate().GoToUrl("https://www.iplocation.net/");
                if (wait == null)
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                var ipTextBox = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("input[type='text']")));
                ipTextBox.Clear();
                ipTextBox.SendKeys(IPAddress);
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("input[type='submit']"))).Click();
                foreach (IWebElement element in driver.FindElements(By.CssSelector("div>.col.col_12_of_12")))
                {
                    if (element.FindElements(By.TagName("h4")).Count > 0)
                    {                          
                         var img = GetElementScreenShort(driver, element);
                        img.Save("test.png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
