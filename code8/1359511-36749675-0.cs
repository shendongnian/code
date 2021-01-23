    Item tokenItem = Sitecore.Context.Database.Items["/sitecore/content/Site Content/Tokens"];
    if (tokenItem.HasChildren)
    {
        var sValue = args.Result.FirstPart;
        foreach (Item child in tokenItem.Children){
            if (child.Template.Name == "Token") {
                string home = child.Fields["Title"].Value;
                string hContent = child.Fields["Content"].Value;
                if (sValue.Contains(home)) {
                    sValue = sValue.Replace(home, hContent);
                }
            }
        }
        args.Result.FirstPart = sValue;
    }
