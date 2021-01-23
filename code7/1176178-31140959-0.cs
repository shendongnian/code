        public enum TestEnum1{
        Null = 0,
        A,
        B,
        C,
        Last
    }
        public enum TestEnum2{
        Null = 0,
        D = TestEnum1.Last,
        E,
        F,
        Last
    }
    public enum TestEnum3{
        Null = 0,
        A = TestEnum2.Last,
        B, 
        D,
    }
