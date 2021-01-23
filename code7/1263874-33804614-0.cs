    class MyClass : IEquatable<MyClass>
    {
        public int ImportantProperty1 { get; set; }
        public int ImportantProperty2 { get; set; }
        public int ImportantProperty3 { get; set; }
        public int ImportantProperty4 { get; set; }
        public int NonImportantProperty { get; set; }
        public bool Equals(MyClass other)
        {
            return
                (!Object.ReferenceEquals(this, null)) &&
                (this.ImportantProperty1 == other.ImportantProperty1) &&
                (this.ImportantProperty2 == other.ImportantProperty2) &&
                (this.ImportantProperty3 == other.ImportantProperty3) &&
                (this.ImportantProperty4 == other.ImportantProperty4);
        }
    }
