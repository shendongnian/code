            IWebElement banner = driver.FindElement(By.Id("banner")).Text;
            bool status = false;
            int tryTimes = 15;
    
            do
            {
                if (banner.Text.Equals("Rolling in 20.00..."))
                {
                    Console.WriteLine("roller ended");
                    status = true;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    banner = driver.FindElement(By.Id("banner")).Text;
                    tryTimes--;
                }
            } while (!status && tryTimes > 0);
