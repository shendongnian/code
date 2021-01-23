    class Program
    {
        static void Main(string[] args)
        {
            string xyz = "abc";
    
            BindingFlags methodflags = BindingFlags.Static | BindingFlags.Public;
    
            MethodInfo mi = typeof(Program).GetMethod("MyFunc", methodflags);
    
            mi.MakeGenericMethod(xyz.GetType()).Invoke(null, null);
        }
    
        public static void MyFunc<T>()
        {
            Console.WriteLine(typeof(T).FullName);
        }
    }
