    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    Actions actions = new Actions(driverFF);
    actions.MoveToElement(element);
    actions.Perform();
