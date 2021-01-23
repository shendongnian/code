    public class Foo : IFoo<string, string>
    {
        void IFoo<string, string>.Bar(string b)
        {
            Console.WriteLine("IFoo<string, string>.Bar: " + b);
        }
        void IBar<string>.Bar(string t)
        {
            Console.WriteLine("IBar<string>.Bar: " + t);
        }
    }
