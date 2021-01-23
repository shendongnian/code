    using System;
    using System.Reflection;
    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo info = RuntimeHelpers.CreateFunction();
            //Create delegate to use our function
            //If you're gonna create function that actually returns something,
            //you need to go for a Func<T, T1> cast instead of Action<T>
            var func = (Action<string>)Delegate.CreateDelegate(typeof (Action<string>), info);
            func("Hello");
            Console.ReadKey();
        }
    }
