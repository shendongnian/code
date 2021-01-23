    var username = "your username";
    var box = Program.Driver.FindElement(By.Id("regFirstName")); // Lookup using Id
    
    // SendKeys is setting the focus on the field and entering a string
    box.SendKeys(username);
