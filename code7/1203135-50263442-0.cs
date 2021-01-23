     //   public void test() 
       {
            IWebDriver driver = new ChromeDriver();
            ClickSaveButton(driver,"MyButton",10); //Wait for 10 seconds
        }
 
     //Customized wait block 
    public void ClickSaveButton(IWebDriver driver,String ElementID = "" int TimeOut)
        {
            Console.Error.WriteLine("Waiting....");
            try
            {
               driver.FindElement(By.Id(ElementID)).Click();
            }
            catch (Exception exception)
            {
                Thread.Sleep(1000);
                if (TimeOut > 0) ClickSaveButton(driver, TimeOut - 1);
            }
        }
