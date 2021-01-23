    public struct PartialViewModel
    {
        public string Foo { get; set; }
        public int Bar { get ; set; }
    }
    . . .
    public struct MainViewModel
    {
        public double Baz { get; set; }
        public PartialViewModel Qux { get; set; }
    }
