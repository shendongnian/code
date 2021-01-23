    [Given(@"I select ""(.*)"" option")]
    public void GivenInISelectOption(string p0)
    {
        if(p0.Equals("SetupMenu"){
            MainMenuPage.SelectOption(MainMenuPage.SetupMenu);
        }     
    }
