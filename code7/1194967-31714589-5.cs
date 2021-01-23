    using System;
    using System.Reflection;
    using System.Timers;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var constructorInfo = typeof(ElapsedEventArgs).GetConstructor(
                    BindingFlags.NonPublic | BindingFlags.Instance, 
                    null, new [] { typeof(int), typeof(int) }, null);
                var elapsedEventArgs = (ElapsedEventArgs)
                    constructorInfo.Invoke(new object[] { 50, 50 });
            }
        }
    }
