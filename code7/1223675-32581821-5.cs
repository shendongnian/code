    [When(@"I click the (.*) button")]
    public void ClickTheButton(string ButtonName)
    {
         myPage.Buttons.First(button=>button.Name==ButtonName).Click;         
    }
    
