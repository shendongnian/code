    class Class6
    {
        static void Main(string[] args)
        {
            Boo b = new Boo { BooMember = 5 };
            Console.WriteLine(b.BooMember);
            
            Foo f = new Foo(b);
            // b is unaffected by the method code which is making new object
            Console.WriteLine(b.BooMember);
                        
            Foo g = new Foo(ref b);
            // b started pointing to new memory location (changed in the method code)
            Console.WriteLine(b.BooMember);
        }
    }
    public class Foo
    {
        Boo a;
        public Foo(Boo b)
        {
            a = b;
            // b is just a reference, and actually is a copy of reference passed,
            // so making it point to new object, dosn't affect actual object , check in calling code
            b = new Boo();
        }
        public Foo(ref Boo b)
        {
            a = b;
            // b is just a reference, but actual reference itself is copied,
            // so making it point to new object would make the calling code object reference to point 
            // to new object. check in the calling code.
            b = new Boo();
        }
    }
    public class Boo
    {
        public int BooMember { get; set; }
    }
