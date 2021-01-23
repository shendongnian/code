    public sealed class Languages : SingletonBase<Languages, Language>
    {
        protected override void PopulateDictionary(string systemLangCode)
        {
            var languages = new List<Language>();
            // some DB stuff
            Dictionary.Add(systemLangCode, languages);
        }
    }
