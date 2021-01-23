    using System;
    using System.Collections.Generic;
    
    namespace Foo
    {
        public class MyClass
        {
            public virtual object Foo(object o1, object o2, object o3, object o4)
            {
                return new object();
            }
        }
    
        public sealed class Program
        {
            public static void Main(string[] args)
            {
                var myClass = new MyClass();
                object x = new object();
                myClass.Foo(null, null, null, new object()); // put a breakpoint here and once it stops, step over (F10) - AccessViolationException should be thrown in VS
            }
        }
    }
