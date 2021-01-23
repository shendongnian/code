    try
    {
        string timeToWait = new String(driver.FindElement(By.Id("banner")).Text.ToCharArray().Where(c => Char.IsDigit(c)).ToArray()).Substring(0,2);
        
        int ttw = Convert.ToInt32(timeToWait);
        
        System.Threading.Thread.Sleep(ttw * 1000);
    }
    catch(Exception ex)
    {}
