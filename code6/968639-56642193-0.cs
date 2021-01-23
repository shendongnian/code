    public static class SeleniumExtensions
    {
        public static IAlert WaitAlert(this ITargetLocator locator, int seconds = 10)
        {
            while (true) 
            {
                try { return locator.Alert(); }
                catch (NoAlertPresentException) when (--seconds >= 0) { Thread.Sleep(1000); }
            }
        }
    }
