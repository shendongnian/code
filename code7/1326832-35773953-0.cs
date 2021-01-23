    public void SelectIn(By by, string value)
    {
        //code here to wait the element be displayed
        //after, the method will select the dropdown with the wanted value
        var dropDownListBox = _driver.FindElement(by);
        var clickThis = new SelectElement(dropDownListBox);
        clickThis.Options.First(o => 
            o.GetAttribute("id") == value || 
            o.Text.Equals(value) || 
            o.GetAttribute("value") == value)
        .Click();
    }
