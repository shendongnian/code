    public string BetterTitileCase(string original)
    {
        string title = /* ToTitleCase call here, etc. */;
        string fixedTitle = "";
        //the title and the original string should be the same length
        for(int i = 0; i < title.length; i++)
        {
            if(original[i].IsLower)
                fixedTitle += title[i];
            else
                fixedTitle += original[i];
        }
        return fixedTitle;
    }
