    namespace Temp
    {
        class A
        {
            public static implicit operator B(A a) { return new B(); }
        }
        class B
        {
            public static B operator *(int c, B b) { return new B(); }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(2 * ((B)new A()));
            }
        }
    }
