    using ParsedData = Dictionary<string, Dictionary<string, A>>;
    class A {
        public int Score;
        public string[] violations;
    }
    var parsed = JsonConvert.DeserializeObject<ParsedData>(…);
