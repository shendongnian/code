    class MyJson
    {
        public string method { get; set; }
        public Dictionary<string,object> parameters { get; set; }
    }
    ................
    string json = "{\"method\":\"subtract\",\"parameters\":{\"minuend\":{\"img\": 3, \"real\": 4},\"subtrahend\":23}}";
    var data = JsonConvert.DeserializeObject<MyJson>(json);
