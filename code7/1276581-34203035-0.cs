    class AbscdeClass
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
    }
    class JsonBody
    {
        public Dictionary<string, AbscdeClass> Profile { get; set; }
    }
