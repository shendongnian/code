    public void WaitUntilLoaded()
        {
            Func<IWebDriver, bool> test = drv =>
            {
              result = (bool?)js.ExecuteScript("return SeleniumHelper.isPageLoaded;");
            };
    
            TestHelper.WaitUntil(this.Driver, d => { }, test, Constants.Pause.Medium, "load", logWaitTime: true);
        }
    internal static class TestHelper
       {
       private static readonly string StartDateString = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
       private static readonly Random Rnd = new Random((int)DateTime.Now.Ticks);
    
       public static void WaitUntil(IWebDriver driver, Action<IWebDriver> action, Func<IWebDriver, bool> predicate, TimeSpan timeOut, string waitingForDescription, bool logWaitTime = false)
       {
           action(driver);
    
           int retryCount = 0;
           var now = DateTime.Now;
           var wait = new WebDriverWait(driver, timeOut);
           Func<IWebDriver, bool> fullPredicate = drv =>
           {
               var res = predicate(drv);
               if (!res)
                   {
                   bool hasErr = IsShowingErrorLoadingPage(drv);
                   if (hasErr)
                   {
                       Console.WriteLine(string.Format("Page is marked with [{0}]", "Error Loading Page"));
                       if (retryCount++ == 0)
                       {
                            Console.WriteLine("Retrying...");
                            action(driver);
                            res = false;
                       }
                    }
                }
    
                return res;
            };
    
            try
            {
                wait.Until(fullPredicate);
            }
            catch (TimeoutException)
            {
                string waitMsg = timeOut.TotalSeconds >= 1 ? (timeOut.TotalSeconds + "s") : (timeOut.TotalMilliseconds + "ms");
                throw new TimeoutException(string.Format("Waited for {0} to {1} without success [{2}].", waitMsg, waitingForDescription, WritePageSource(driver)));
            }
    
            if (logWaitTime)
            {
                Console.WriteLine("WaitUntil: Requested wait: " + Math.Round(timeOut.TotalSeconds, 2).ToString("0.00").PadLeft(5, ' ') + "s; actual wait: " + Math.Round(DateTime.Now.Subtract(now).TotalSeconds, 3).ToString("0.000").PadLeft(6, ' ') + "s");
            }
      }
      
     public static bool IsStale(IWebElement element)
     {
         return Throws<StaleElementReferenceException>(() => element.GetAttribute("x"));
     }
     public static bool IsShowingErrorLoadingPage(IWebDriver driver)
     {
            IWebElement failedToLoad;
            try
            {
                failedToLoad = driver.FindElements(By.TagName("h1")).Where(el => el.Text == "Error Loading Page").FirstOrDefault();
            }
            catch (StaleElementReferenceException)
            {
                failedToLoad = null;
            }
            return failedToLoad != null;
        }
    }
