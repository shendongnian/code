    class MyJson
    {
        public string method { get; set; }
        public Dictionary<string,string> parameters { get; set; }
    }
    ................
    string json = "{\"method\":\"subtract\",\"parameters\":{\"minuend\":42,\"subtrahend\":23}}";
    var data = JsonConvert.DeserializeObject<MyJson>(json);
