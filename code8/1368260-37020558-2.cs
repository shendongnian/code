    IList<IWebElement> otherSports = Driver.FindElements(By.CssSelector(".sports-buttons-container .other-sport .sport-name"));
    List<string> x = new List<string>();
    var alphabetical = true;
    string previous = null;
    
    foreach (var item in otherSports)
    {
        string btnText = item.Text.Replace(System.Environment.NewLine, "");
        var current = item.Text.Replace(System.Environment.NewLine, "");
        x.Add(current);
        if (previous != null && StringComparer.Ordinal.Compare(previous,current) > 0)
        {
            alphabetical = false;
        }
        previous = current;
    }
