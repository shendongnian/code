         protected void SwitchToFrame(int iframe = 1)
        {
            var driver = GetWebDriver();
            driver.SwitchTo().DefaultContent();
            bool done = false, timeout = false;
            int counter = 0;
            do
            {
                counter++;
                try
                {
                    driver.SwitchTo().Frame(iframe);
                    done = true;
                }
                catch (OpenQA.Selenium.NoSuchFrameException)
                {
                    if (counter <= Constants.GLOBAL_MAX_WAIT_SEC)
                    {
                        Wait(1);
                        continue;
                    }
                    else timeout = true;
                } 
            } while (!done && !timeout);
            if (timeout) throw new OpenQA.Selenium.NoSuchFrameException(iframe.ToString());
        }
