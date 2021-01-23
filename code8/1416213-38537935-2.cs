         IWebElement element = driver.FindElement(By.Xpath("(//input[@id = 'XXXX'])[1]"));
         element.Click();
     Or try as below using `By.Id()` :-
        IList<IWebElement> elements = driver.FindElements(By.Id("XXXX"));
        elements[0].Click();
