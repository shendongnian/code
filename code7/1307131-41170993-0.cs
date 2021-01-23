    private void FrenchUI()
        {
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            LocalizeDictionary.Instance.Culture = new CultureInfo(ConfigurationManager.AppSettings["Culture"])//fr-CA;
        }
        private void EnglishUI()
        {
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            LocalizeDictionary.Instance.Culture = new CultureInfo(ConfigurationManager.AppSettings["CultureUS"]);//en-US
        }
