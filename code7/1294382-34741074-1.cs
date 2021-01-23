    foreach (var item in tableRow)
    {
        IWebElement column7 = item.FindElement(By.CssSelector("[class*='col7']"));
        IWebElement column9 = item.FindElement(By.CssSelector("[class*='col9']"));
        if (column7.Text.Equals("Suspended") && column9.Text.Equals("Publishing Failed"))
            Assert.Fail("Failed because column8 is 'Suspended' and column10 is 'Publishing Failed'");
        else
            Assert.Pass();
    }
