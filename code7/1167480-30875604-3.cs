    public string BetterTitileCase(string original)
    {
        string title = /* ToTitleCase call here, etc. */;
        StringBuilder fixedTitle = new StringBuilder();
        //the title and the original string should be the same length
        for(int i = 0; i < title.length; i++)
        {
            if(original[i].IsLower)
                fixedTitle.Append(title[i]);
            else
                fixedTitle.Append(original[i]);
        }
        return fixedTitle.ToString();
    }
