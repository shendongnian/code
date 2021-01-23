    [CategoryOrder("General", 1)]
    [CategoryOrder("Advanced", 2)]
    [CategoryOrder("Other", 3)]
    public class MyClass
    {
        [Category("General")]
        public string Property1 { get; set; }
        [Category("Advanced")]
        public int Property2 { get; set; }
        [Category("Other")]
        public double Property3 { get; set; }
        [Category("General")]
        public string Property4 { get; set; }
        [Category("Advanced")]
        public int Property5 { get; set; }
        [Category("Other")]
        public double Property6 { get; set; }
    }
