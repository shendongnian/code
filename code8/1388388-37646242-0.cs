    using System;
    using System.Runtime.Remoting.Messaging;
    using System.Threading;
    
    namespace OriginalCallStackIsLostOnRethrow
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    A2();
                    // A3();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
    
            static void A2() { B2(); }
            static void B2() { C2(); }
            static void C2() { D2(); }
            static void D2()
            {
                Action action = () => 
                {
                    Console.WriteLine($"D2 called on worker #{Thread.CurrentThread.ManagedThreadId}. Exception will occur while running D2");
                    throw new DivideByZeroException();    
                };
                action.BeginInvoke(ar =>
                {
                    ((Action)((ar as AsyncResult).AsyncDelegate)).EndInvoke(ar);
    
                    Console.WriteLine($"D2 completed on worker thread #{Thread.CurrentThread.ManagedThreadId}");
                }, null);
            }
    
            static void A3() { B3(); }
            static void B3() { C3(); }
            static void C3() { D3(); }
            static void D3()
            {
                Action action = () => { Console.WriteLine($"D2 called on worker #{Thread.CurrentThread.ManagedThreadId}."); };
                action.BeginInvoke(ar =>
                {
                    try
                    {
                        Console.WriteLine($"D2 completed on worker thread #{Thread.CurrentThread.ManagedThreadId}. Oh, but wait! Exception!");
                        throw new DivideByZeroException();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }, null);
                
            }
        }
    }
