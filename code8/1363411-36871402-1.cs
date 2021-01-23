    public class Middle
    {
        private Middle() { "Middle".Dump(); }
        public Middle(int Foo) { "Middle".Dump(); }
        public Root Root { get; set; }
        public Child Child { get; set; }
    }
