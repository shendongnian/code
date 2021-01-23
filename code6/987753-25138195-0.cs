    public string GetLanguages()
    {
        string[] langNames =InputLanguage.InstalledInputLanguages
                .OfType<InputLanguage>()
                .Select(lang => string.Format("{0}", lang.Culture.EnglishName))
                .ToArray(); 
        // This is a simple Join, just to give you the idea
        // You better use a proper serialization like JSON
        return string.Join(";", langNames);
    }
