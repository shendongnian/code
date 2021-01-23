    var reg = new Regex(@"^item_id - (.+) \(moreInfo\)$");
    string test = "item_id - description (moreInfo)";
    var match = reg.Match(test);
    if(match.Success)
    {
        if(match.Groups.Count > 1)
        {
            var group = match.Groups[1];
            System.Diagnostics.Debug.Print(group.Value); // prints your description....
        }
    }
