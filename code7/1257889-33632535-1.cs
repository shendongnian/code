    private static string getText(RadGridStringId id)
    {
        if (texts == null)
        {
            InitializeTexts();
        }
        if (texts.ContainsKey(id))
        {
            return texts[id];
        }
        else
        {
            return string.Empty; // or base.GetLocalizedString(id);
        }
    }
