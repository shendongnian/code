    static void checkPopup(object sender, OpenQA.Selenium.Support.Events. WebElementEventArgs e) {
         EventFiringWebDriver driver = (sender as OpenQA.Selenium.Support.Events.EventFiringWebDriver);
         try {
             Alert alert = driver.SwitchTo().Alert();
             alert.accept();
         }
         catch (NoAlertPresentException ex) { 
             // nothing to do - just continue
         }
    }
