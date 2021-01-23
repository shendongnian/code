    using System;
    
    namespace ConsoleApplication3
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                // using a method
                MyEvent += Program_MyEvent;
    
                // using EventHandler, possible but not mandatory
                MyEvent += new EventHandler(Target);
             
                // using lambda syntax
                MyEvent += (sender, eventArgs) => { };
    
                // using delegate
                MyEvent += delegate (object sender, EventArgs eventArgs) { };
    
                // using delegate, signature is optional actually
                MyEvent += delegate { };
            }
    
            private static void Target(object sender, EventArgs eventArgs)
            {
            }
    
            private static void Program_MyEvent(object sender, EventArgs e)
            {
            }
    
            public static event EventHandler MyEvent;
        }
     
    }
