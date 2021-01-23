    public class SheetRoot
    {
        [JsonProperty("Sheet1")]
        public List<Row> Sheet { get; set; }
    }
    public class Row
    {
        [JsonProperty("one")]
        public int Col1 { get; set; }
        [JsonProperty("two")]
        public int Col2 { get; set; }
    }
    var res = JsonConvert.DeserializeObject<SheetRoot>(s);
