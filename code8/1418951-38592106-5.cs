    using System;
    
    namespace SandboxConsole
    { 
        class Program
        {
            static void Main(string[] args)
            {
                using (var context = new TestClass())
                {
                    
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
    
                    Console.WriteLine("After collection");
                }
                Console.WriteLine("After dispose, before 2nd collection");
    
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
    
                Console.WriteLine("After 2nd collection");
                Console.ReadLine();
            }
        }
    
        internal class TestClass : IDisposable
        {
            public void Dispose()
            {
                Dispose(true);
            }
    
            ~TestClass()
            {
                Console.WriteLine("In finalizer");
                Dispose(false);
            }
    
            private void Dispose(bool isDisposing)
            {
                Console.WriteLine("In Dispose: {0}", isDisposing);
                if (isDisposing)
                {
                    //uncomment this line out to have the finalizer never run
                    //GC.SuppressFinalize(this);
                }
            }
        }
    }
