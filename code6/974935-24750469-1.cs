    public void viewoffers(IWebDriver driver, string user, string pass)
    {
        while (true)
        {
            Thread.Sleep(timespan);
            try { int c = driver.WindowHandles.Count; }
            catch { AbortThread(user); }
            driver.Navigate().GoToUrl("https://as.realtrans.com/webtop/orders/offers/offer_order_viewInfo.asp?user=" + user);
            try { int c = driver.WindowHandles.Count; }
            catch { AbortThread(user); }
            if (driver.Url.ToString().Contains("offer_order_viewInfo.asp?user="))
            {
                try { int c = driver.WindowHandles.Count; }
                catch { AbortThread(user); }
                if (driver.PageSource.Contains("id=\"chkOffer\""))
                {
                    driver.FindElement(By.Id("chkOffer")).Click();
                    driver.FindElement(By.ClassName("CellClass")).FindElement(By.TagName("a")).Click();
                    driver.FindElement(By.Name("btnSubmit")).Click();
                }
            }
            else
            {
                break;
            }
        }
        
        this.reopenaccount(driver, user, pass);
    }
}
