    public class FooBarVm {
        public int id { get; set; }
        public BarRecord bar { get; set; }
        public string foo { get; set; }
        public int barbaz_id { get; set; }
        public string barbaz_name { get; set; }
    }
    public class FooBarRecord {
        public int id { get; set; }
        public BarRecord bar { get; set; }
        public string foo { get; set; }
        public int foo2 { get; set; }
        public BarBazRecord barbaz { get; set; }
    }
    public class BarRecord {
        public int id { get; set; }
        public BarBazRecord baz { get; set; }
        public string bar1 { get; set; }
        public int bar2 { get; set; }
    }
    public class BarBazRecord {
        public int id { get; set; }
        public string name { get; set; }
    }
