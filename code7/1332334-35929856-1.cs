    class A {
        public int Score;
        public string[] violations;
    }
    class B : Dictionary<string, A> {}
    class C : Dictionary<string, B> {}
    var parsed = JsonConvert.DeserializeObject<C>(…);
