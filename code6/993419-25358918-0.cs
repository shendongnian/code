    ie.FindElement(By.Id("BirthMonth")).Click();
    System.Threading.Thread.Sleep(1000);
    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> months = ie.FindElement(By.ClassName("goog-menu-vertical")).FindElements(By.ClassName("goog-menuitem-content"));
    months[new Random().Next(0, 11)].Click();
    System.Threading.Thread.Sleep(3000);
