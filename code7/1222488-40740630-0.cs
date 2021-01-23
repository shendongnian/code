    public static class MyEnum
    {
        public const string Foo = "Foo";
        public const string Bar = "Bar";
    }
    public class Client
    {
        public string MyVal { get; set; }
        public Client()
        {
            MyVal = MyEnum.Bar;
        }
    }
