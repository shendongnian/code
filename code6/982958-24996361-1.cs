    [When("I click on (.*)")]
    public void WhenIClickOn(ButtonIdentifier buttonId)
    {
        _driver.FindElement(By.Id(buttonId.Identifier)).Click(); 
    }
    [StepArgumentTransformation]
    public ButtonIdentifier GetButtonIdentifier(string buttonValue)
    {
         switch (buttonValue)
         {
              case "Google Search":
                   return new ButtonIdentifier("gbqfba");
              case "I'm feeling lucky":
                   return new ButtonIdentifier("gbqfsb");
              default:
                   throw new ArgumentOutOfRangeException();          
         }
    }
    
