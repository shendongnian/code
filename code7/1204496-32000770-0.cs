    var json = "[{\"symbol\":\"@CL.1\",\"symbolType\":\"symbol\",\"code\":0,\"name\":\"WTI Crude Oil(Sep\u002715)\",\"shortName\":\"OIL\",\"last\":\"42.14\",\"exchange\":\"New York Mercantile Exchange\","+
               "\"source\":\"\",\"open\":\"42.23\",\"high\":\"42.26\",\"low\":\"41.35\",\"change\":\" - 0.09\",\"currencyCode\":\"USD\",\"timeZone\":\"EDT\",\"volume\":\"6526\","+
               "\"provider\":\"CNBC Quote Cache\",\"altSymbol\":\"CL / U5\",\"curmktstatus\":\"REG_MKT\",\"realTime\":\"false\",\"assetType\":\"DERIVATIVE\",\"noStreaming\":\"false\",\"encodedSymbol\":\" % 40CL.1\"}]";
    dynamic foo = JsonConvert.DeserializeObject<List<Foo>>(json);
    public class Foo
    {
        public string symbol { get; set; }
        public string symbolType { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string last { get; set; }
        public string exchange { get; set; }
        public string source { get; set; }
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string change { get; set; }
        public string currencyCode { get; set; }
        public string timeZone { get; set; }
        public string volume { get; set; }
        public string provider { get; set; }
        public string altSymbol { get; set; }
        public string curmktstatus { get; set; }
        public string realTime { get; set; }
        public string assetType { get; set; }
        public string noStreaming { get; set; }
        public string encodedSymbol { get; set; }
    }
