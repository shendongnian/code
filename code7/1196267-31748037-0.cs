    using System;
    
    class Test
    {
        static void Main()
        {
            Action<Test> foo = (Action<Test>)
                Delegate.CreateDelegate(typeof(Action<Test>), typeof(Test).GetMethod("Foo"));
            foo(null); // Prints Weird
            Action<Test> bar = (Action<Test>)
                Delegate.CreateDelegate(typeof(Action<Test>), typeof(Test).GetMethod("Bar"));
            bar(null); // Throws
        }
        
        public void Foo()
        {
            Console.WriteLine(this == null ? "Weird" : "Normal");
        }
    
        public virtual void Bar()
        {
            Console.WriteLine(this == null ? "Weird" : "Normal");
        }
    }
