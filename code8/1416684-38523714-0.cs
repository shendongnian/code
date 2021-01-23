     class Program
        {
            
     
        static void Main(string[] args)
        {
            var a = new A();
            var str = JsonConvert.SerializeObject(a);
            Console.Write(str);
        }
    }
    
    public class A
    {
        public string Name { get; } = "Johny Bravo";
        [JsonIgnore]
        public B ComplexProperty { get; } = new B();
        [JsonProperty("ComplexProperty")]
        public int complexValue => ComplexProperty.Prop3;
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
