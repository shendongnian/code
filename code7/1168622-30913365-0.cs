    using System.Reflection;
    
    class TestPointer
    {    
        unsafe static void Main()
        {
            char c = 'x';
            char* p = &c;
            object boxedPointer = Pointer.Box(p, typeof(char*));
            
            var method = typeof(TestPointer).GetMethod("Foo");
            method.Invoke(null, new[] { boxedPointer });
            Console.WriteLine("After call, c = {0}", c);
        }
        
        public static unsafe void Foo(char *pointer)
        {
            Console.WriteLine("Received: {0}", *pointer);
            *pointer = 'y';
        }
    }
