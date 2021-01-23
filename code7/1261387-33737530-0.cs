    void Main()
    {
        const string filePath = @"C:\FilePath\json.txt";
        const string testJson = @"{""glossary"": {""title"": ""example glossary"",		""GlossDiv"": {""title"": ""S"",			""GlossList"": {""GlossEntry"": {""ID"": ""SGML"",					""SortAs"": ""SGML"",					""GlossTerm"": ""Standard Generalized Markup Language"",					""Acronym"": ""SGML"",					""Abbrev"": ""ISO 8879:1986"",					""GlossDef"": {""para"": ""A meta-markup language, used to create markup languages such as DocBook."",						""GlossSeeAlso"": [""GML"", ""XML""]},					""GlossSee"": ""markup""}}}}}";
    
        // Now we have our Json Object...
        SampleJson sample = JsonConvert.DeserializeObject<SampleJson>(testJson);
        
        // We convert it back into a string with indentation...
        string jsonString = JsonConvert.SerializeObject(sample, Newtonsoft.Json.Formatting.Indented);
        
        // Now simply save to file...
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(jsonString);
        }
        
        Process.Start(filePath);
    }
    
    // The following classes are what the `testJson` string is deserialized into.
    public class GlossDef
    {
        [JsonProperty("para")]
        public string Para { get; set; }
        [JsonProperty("GlossSeeAlso")]
        public string[] GlossSeeAlso { get; set; }
    }
    public class GlossEntry
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("SortAs")]
        public string SortAs { get; set; }
        [JsonProperty("GlossTerm")]
        public string GlossTerm { get; set; }
        [JsonProperty("Acronym")]
        public string Acronym { get; set; }
        [JsonProperty("Abbrev")]
        public string Abbrev { get; set; }
        [JsonProperty("GlossDef")]
        public GlossDef GlossDef { get; set; }
        [JsonProperty("GlossSee")]
        public string GlossSee { get; set; }
    }
    public class GlossList
    {
        [JsonProperty("GlossEntry")]
        public GlossEntry GlossEntry { get; set; }
    }
    public class GlossDiv
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("GlossList")]
        public GlossList GlossList { get; set; }
    }
    public class Glossary
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("GlossDiv")]
        public GlossDiv GlossDiv { get; set; }
    }
    public class SampleJson
    {
        [JsonProperty("glossary")]
        public Glossary Glossary { get; set; }
    }
