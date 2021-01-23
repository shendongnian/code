    // DO NOT USE THIS CODE
    using System;
    
    public class Evil
    {
        public void Method()
        {
            Console.WriteLine($"Is this null? {this == null}");
        }    
    }
    
    
    class Test
    {
        static void Main()
        {
            var method = typeof(Evil).GetMethod("Method");
            var action = (Action<Evil>) Delegate.CreateDelegate(typeof(Action<Evil>), method);
            action(null);
        }    
    }
