            public void WaitForPageLoading(int secondsToWait = 600)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                try
                {
                    while (sw.Elapsed.TotalSeconds < secondsToWait)
                    {
                        var pageIsReady = (bool)((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState == 'complete'");
                        if (pageIsReady)
                            break;
                        Thread.Sleep(100);
                    }
                }
                catch (Exception)
                {
                    Driver.Dispose();
                    throw new TimeoutException("Page loading time out time has passed " + secondsToWait + " seconds");
                }
                finally
                {
                    sw.Stop();
                }
            }
