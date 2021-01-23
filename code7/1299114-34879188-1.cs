    class TestClass
    {
        public int Foo { get; set; }
    
        public double Bar { get; set; }
    
        public string Baz { get; set; }
    
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture, 
                "{{T: TestClass, Foo: {0}, Bar: {1}}}",
                this.Foo,
                this.Bar);
        }
    }
