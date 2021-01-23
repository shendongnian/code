    class Program
    {
      
        static void Main(string[] args)
        {
            //
            OurCallback();
        }
        public static IntPtr GetFunctionPointer()
        {
            A obj1 = new A();
            RuntimeMethodHandle method = ((Action)obj1.Method1).Method.MethodHandle;
            IntPtr p = method.GetFunctionPointer();
            return p;
        }
        public unsafe static void OurCallback()
        {
          var k =  GetFunctionPointer();
          void* p = k.ToPointer();
          
        }
        struct A
        {
            public void Method1()
            {
                Console.WriteLine("\nTest!");
            }
        }
    }
