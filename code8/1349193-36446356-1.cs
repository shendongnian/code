    public enum Language
    {
        [LangValue(Lang.af)]
        Afrikaans,
        [LangValue(Lang.sq)]
        Albanian,
        [LangValue(Lang.ar)]
        Arabic,
        [LangValue(Lang.be)]
        Belarusian,
        [LangValue(Lang.bg)]
        Bulgarian,
        [LangValue(Lang.ca)]
        Catalan,
    }
    public enum Lang
    {
        [LanguageValue(Language.Afrikaans)]
        af,
        [LanguageValue(Language.Albanian)]
        sq,
        [LanguageValue(Language.Arabic)]
        ar,
        [LanguageValue(Language.Belarusian)]
        be,
        [LanguageValue(Language.Bulgarian)]
        bg,
        [LanguageValue(Language.Catalan)]
        ca,
    }
    public class LanguageValue : Attribute
    {
        public LanguageValue(Language e)
        {
            _LanguageValue = e;
        }
        public Language _LanguageValue { get; set; }
    }
    public class LangValue : Attribute
    {
        public LangValue(Lang e)
        {
            _LangValue = e;
        }
        public Lang _LangValue { get; set; }
    }
