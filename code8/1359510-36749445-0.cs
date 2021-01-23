    public void Process(RenderFieldArgs args)
    {
        args.Result.FirstPart = this.Replace(args.Result.FirstPart);
        args.Result.LastPart = this.Replace(args.Result.LastPart);
    }
    
    protected string Replace(string input)
    {
        Item tokenItem = Sitecore.Context.Database.Items["/sitecore/content/Site Content/Tokens"];
    
        if (tokenItem.HasChildren)
        {
            foreach (Item child in tokenItem.Children)
            {
                if (child.Template.Name == "Token")
                {
                    string home = child.Fields["Title"].Value;
                    string hContent = child.Fields["Content"].Value;
                    if (input.Contains(home))
                    {
                        return input.Replace(home, hContent);
                    }
                }
            }
        }
    
        return input;
    }
