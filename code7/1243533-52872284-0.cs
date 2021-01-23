    class TestObject {
        public int A { get; set; }
        public int alpha { set => A = value; }
        public int omega { set => A = value; }
    }
