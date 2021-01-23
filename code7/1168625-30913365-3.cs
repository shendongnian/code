    using System.Reflection;
    
    class TestRef
    {    
        unsafe static void Main()
        {
            var method = typeof(TestRef).GetMethod("Foo");
            var args = new object[] { 10 };
            method.Invoke(null, args);
            Console.WriteLine("After call, args[0] = {0}", args[0]);
        }
        
        public static unsafe void Foo(ref int x)
        {
            Console.WriteLine("Received: {0}", x);
            x = 20;
        }
    }
