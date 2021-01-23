    class Program
    {
        static void Main(string[] args)
        {
            var a = new A() { property = "someValue" };
            string obj = (string)teste;
        }
    }
    class A
    {
        public string property { get; set; }
        public static implicit operator string(A t)
        {
            if (t == null)
                return null;
            return t.property;
        }
    }
