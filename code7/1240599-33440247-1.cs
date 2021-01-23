    public class Demo
    {
        public static void Main()
        {
            Foo foo = new Foo {SizeOfSailBoat = 10};
            var result = foo.OrderBy(f => f.SizeOfSailBoat);
        }
    }
