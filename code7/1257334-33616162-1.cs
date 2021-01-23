    public class TopLevel
    {
        public class InsideClass
        {
            public string SomeProperty { get; set; }
        }
        public InsideClass MyInsideClass { get; set; }
        public TopLevel()
        {
            MyInsideClass = new InsideClass();
        }
    }
