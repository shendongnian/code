        IWebElement banner = driver.FindElement(By.Id("banner")).Text;
        bool status = false;
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
            }
        } while (!status);
