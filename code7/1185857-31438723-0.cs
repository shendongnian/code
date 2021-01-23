        public static void WaitUntil(this IWebDriver webDriver, Func<IWebDriver, bool> predicate, TimeSpan timeout)
        {
            var dtStart = DateTime.Now;
            while (true)
            {
                try
                {
                    if (!predicate(webDriver))
                        throw new Exception();
                    break;
                }
                catch (Exception ex)
                {
                    if (DateTime.Now.Subtract(dtStart) >= timeout)
                        throw ex;
                }
                Thread.Sleep(30000);
            }
        }
        public static void WaitUntil(this IWebDriver webDriver, Func<IWebDriver, IWebElement> predicate, TimeSpan timeout)
        {
            var dtStart = DateTime.Now;
            while (true)
            {
                try
                {
                    predicate(webDriver);
                    break;
                }
                catch (Exception ex)
                {
                    if (DateTime.Now.Subtract(dtStart) >= timeout)
                        throw ex;
                }
                Thread.Sleep(30000);
            }
        }
