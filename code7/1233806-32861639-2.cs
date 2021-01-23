    public class MyCustomAttribute : Attribute { }
    
    public class Program
    {
        [MyCustomAttribute]
        public string Test { get; set; }
    
        public void Main(string[] args)
        {
            var propertyInfo = typeof(Program).GetProperty("Test");
            var defined = propertyInfo.IsAttributeDefined<MyCustomAttribute>();
        }
    }
