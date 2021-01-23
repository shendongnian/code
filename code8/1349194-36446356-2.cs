    public static class ExtensionsMethods
    {
        public static Lang GetLang(this Language la)
        {
            var l = la.GetType().GetField(la.ToString()).GetCustomAttributes(typeof(LangValue), false).First() as LangValue;
            return l._LangValue;
        }
        public static Language GetLanguage(this Lang la)
        {
            var l = la.GetType().GetField(la.ToString()).GetCustomAttributes(typeof(LanguageValue), false).First() as LanguageValue;
            return l._LanguageValue;
        }
    }
