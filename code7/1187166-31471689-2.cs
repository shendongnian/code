    public class Constants
    {
        public const int Foo = 10;
        static Constants()
        {
            Console.WriteLine("Constants is being initialized");
        }
    }
    class Program
    {
        static void Main()
        {
            // This won't provoke "Constants is being initialized"
            Console.WriteLine(Constants.Foo);
            // The IL will be exactly equivalent to:
            // Console.WriteLine(10);
        }
    }
