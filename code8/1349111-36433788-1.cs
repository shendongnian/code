    // WARNING - if you add members update impacted Range attributes
    public enum MyEnum
    {
        foo,
        bar,
        baz
    }
    [Range(0, 3)]
    class Test
    {
        public Test()
        {
            int enumCount = Enum.GetNames(typeof(MyEnum)).Length;
            int rangeMax = GetType().GetCustomAttributes(typeof(Range), false).OfType<Range>().First().Max;
            Debug.Assert(enumCount == rangeMax);
        }
        static void Main(string[] args)
        {
            var test = new Test();
        }
    }
