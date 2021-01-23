    public string ChangeLanguage(string language) 
    {
        if (string.IsNullOrEmpty(language))
        {
            Debug.Fail("language is NOK");
            language = _fallbackLanguage;
        }
    }
