    public class A
    {
        public string Name { get; } = "Johny Bravo";
    --> [JsonIgnore]
        public B ComplexProperty { get; } = new B();
     -->[JsonProperty(PropertyName = "ComplexProperty")]
    --> public string ComplexPropertyText { get{ return ComplexProperty.ToString(); } }
    }
    
    public class B
    {
        public string Prop1 { get; } = "value1";
        public string Prop2 { get; } = "value2";
        public int Prop3 { get; } = 100;
    
        public override string ToString()
        {
            return this.Prop3.ToString();
        }
    }
