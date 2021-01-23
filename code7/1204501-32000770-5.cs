    var json = "[{\"symbol\":\"@CL.1\",\"symbolType\":\"symbol\",\"code\":0,\"name\":\"WTI Crude Oil(Sep\u002715)\",\"shortName\":\"OIL\",\"last\":\"42.14\",\"exchange\":\"New York Mercantile Exchange\","+
               "\"source\":\"\",\"open\":\"42.23\",\"high\":\"42.26\",\"low\":\"41.35\",\"change\":\" - 0.09\",\"currencyCode\":\"USD\",\"timeZone\":\"EDT\",\"volume\":\"6526\","+
               "\"provider\":\"CNBC Quote Cache\",\"altSymbol\":\"CL / U5\",\"curmktstatus\":\"REG_MKT\",\"realTime\":\"false\",\"assetType\":\"DERIVATIVE\",\"noStreaming\":\"false\",\"encodedSymbol\":\" % 40CL.1\"}]";
    var foo = JsonConvert.DeserializeObject<List<Foo>>(json);
    public class Foo
    {
        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }
        [DataMember(Name = "symbolType")]
        public string SymbolType { get; set; }
        [DataMember(Name = "code")]
        public int Code { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }
        [DataMember(Name = "last")]
        public string Last { get; set; }
        [DataMember(Name = "exchange")]
        public string Exchange { get; set; }
        [DataMember(Name = "source")]
        public string Source { get; set; }
        [DataMember(Name = "open")]
        public string Open { get; set; }
        [DataMember(Name = "high")]
        public string High { get; set; }
        [DataMember(Name = "low")]
        public string Low { get; set; }
        [DataMember(Name = "change")]
        public string Change { get; set; }
        [DataMember(Name = "currencyCode")]
        public string CurrencyCode { get; set; }
        [DataMember(Name = "timeZone")]
        public string TimeZone { get; set; }
        [DataMember(Name = "volume")]
        public string Volume { get; set; }
        [DataMember(Name = "provider")]
        public string Provider { get; set; }
        [DataMember(Name = "altSymbol")]
        public string AltSymbol { get; set; }
        [DataMember(Name = "curmktstatus")]
        public string Curmktstatus { get; set; }
        [DataMember(Name = "realTime")]
        public string RealTime { get; set; }
        [DataMember(Name = "assetType")]
        public string AssetType { get; set; }
        [DataMember(Name = "noStreaming")]
        public string NoStreaming { get; set; }
        [DataMember(Name = "encodedSymbol")]
        public string EncodedSymbol { get; set; }
    }
