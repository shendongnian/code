    public static Parser<string> Key = Parse.CharExcept('=').Many().Text();
    public static Parser<string> Value = Parse.CharExcept(';').Many().Text();
    public static Parser<KeyValuePair<string, string>> ParameterTuple =
        from key in Key
        from eq in Parse.Char('=')
        from value in Value
        select new KeyValuePair<string, string>(key, value);
    public static Parser<string> FixedStuff = Parse.String("input=some/fixed/stuff").Text();
    public static Parser<Config> Configuration =
        from fixedStuff in FixedStuff
        from _ in Parse.Char(';')
        from kvps in ParameterTuple.DelimitedBy(Parse.Char(';'))
        select new Config(fixedStuff, kvps.ToDictionary(x => x.Key, x => x.Value));
    public class Config
    {
        public Config(string fixedStuff, IReadOnlyDictionary<string, string> dict)
        {
            FixedStuff = fixedStuff;
            Dict = dict;
        }
        public string FixedStuff { get; }
        public IReadOnlyDictionary<string, string> Dict { get; }
    }
    [Fact]
    public void ParseIt()
    {
        Configuration.Parse("input=some/fixed/stuff;and=a;list=of;arbitrary=key;value=pairs");
    }
