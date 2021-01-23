    public class Phrases
    {
        public class PhraseData
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore, Order = 1, DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string text { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore, Order = 2, DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string htmlColor { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore, Order = 3, DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int position { get; set; }
            public static PhraseData operator + (PhraseData pd1, PhraseData pd2)
            {
                var pd = new PhraseData();
                pd.text = (pd1.text == null) ? pd2.text : pd1.text;
                pd.htmlColor = (pd1.htmlColor == null) ? pd2.htmlColor : pd1.htmlColor;
                pd.position = (pd1.position == 0) ? pd2.position : pd1.position;
                return pd;
            }
        }
        public PhraseData intro { get; set; }
        public PhraseData credit { get; set; }
        public PhraseData general { get; set; }
        public static Phrases operator + (Phrases p1, Phrases p2)
        {
            return new Phrases() { 
                intro = p1.intro + p2.intro,
                credit = p1.credit + p2.credit,
                general = p1.general + p2.general
            };
        }
    }
