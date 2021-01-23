    [When(@"I add a widget")]
    public void AddAWidget(string ButtonName)
    {
         ClickTheButton("Add")        
    }
    private void ClickTheButton(string ButtonName)
    {
         myPage.Buttons.First(button=>button.Name==ButtonName).Click;         
    }
