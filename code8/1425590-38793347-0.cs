    class Response
    {
        public Dictionary<string, List<Info>> Items { get; set; }
        public string[] Errors { get; set; }
    }
	
    class Info
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public int Prop3 { get; set; }
        public bool Prop4 { get; set; }
    }
