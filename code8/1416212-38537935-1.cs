        IWebElement element = driver.FindElement(By.Xpath("//input[@value = '5273786']"));
         element.Click();
     Or try as below using `By.Id()` :-
          IList<IWebElement> elements = driver.FindElements(By.TagName("select"));
          var element = selectElements.Where(se => se.GetAttribute('value') == '5273786');
          element.Click();
