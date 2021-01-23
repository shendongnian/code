    using System;
    using System.Threading.Tasks;
    namespace Demo
    {
        class MyClass
        {
            public void DoSomething()
            {
                Console.WriteLine("Attempting to enter the DoSomething lock.");
                lock (this) // Change to lock(_locker) to prevent the deadlock.
                {
                    Console.WriteLine("In the DoSomething lock.");
                }
            }
            readonly object _locker = new object();
        }
        internal static class Program
        {
            static void Main(string[] args)
            {
                var myClass = new MyClass();
                lock (myClass)
                {
                    var task = Task.Run(() => myClass.DoSomething());
                    Console.WriteLine("Waiting for the task to complete.");
                
                    if (!task.Wait(1000))
                        Console.WriteLine("ERROR: The task did not complete.");
                    else
                        Console.WriteLine("Task completed.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
                                            
