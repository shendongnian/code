    public string BetterTitileCase(string original)
    {
        string title = /* ToTitleCase call here, etc. */;
        string fixedTitle = "";
        for(int i = 0; i < title.length; i++)
        {
            if(original[i].IsLower)
                fixedTitle += original[i];
            else
                fixedTitle += title[i];
        }
        return fixedTitle;
    }
