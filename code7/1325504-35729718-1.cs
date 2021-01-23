    class MyClass
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Citizenship { get; set; }
        public IEnumerable<MyOtherClass> SomeProperty { get; set; }
    }
    class MyOtherClass
    {
        public string Pincode { get; set; }
        public string Dis { get; set; }
    }
