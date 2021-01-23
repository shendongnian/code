    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Reflection;
    using System.Threading;
    
    namespace Test
    {
        class Program
        {
            public delegate int RecoveryDelegate(IntPtr parameter);
    
            [DllImport("kernel32.dll")]
            private static extern int RegisterApplicationRecoveryCallback(
                    RecoveryDelegate recoveryCallback,
                    IntPtr parameter,
                    uint pingInterval,
                    uint flags);
    
            [DllImport("kernel32.dll")]
            private static extern void ApplicationRecoveryFinished(bool success);
    
            private static void RegisterForRecovery()
            {
                var callback = new RecoveryDelegate(p=>
                {
                    Recover();
                    ApplicationRecoveryFinished(true);
                    return 0;
                });
    
                var interval = 100U;
                var flags = 0U;
    
                RegisterApplicationRecoveryCallback(callback,IntPtr.Zero,interval,flags);
            }
    
            private static void Recover()
            {
                //do the recovery and cleanup
                Process.Start(Assembly.GetEntryAssembly().Location);
            }
    
            private static unsafe void Crash1()
            {
                var p = (int*)0;
                p[0] = 0;
            }
    
            private static unsafe void Crash2()
            {
                var v = 1;
                var p =&v;
                p -= ulong.MaxValue;
                p[0] = 0;
            }
    
            static void Main(string[] args)
            {
                AppDomain.CurrentDomain.UnhandledException +=
                    new UnhandledExceptionEventHandler((s, e) =>
                    {
                        Recover();
                        Environment.Exit(1);
                    });
    
                RegisterForRecovery();
    
                for (var i = 3; i > 0; i--)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("Crash in {0}", i);
                    Thread.Sleep(1000);
                }
    
                //different type of crash
                throw new Exception("Crash.");
                //Environment.FailFast("Crash.");
                //Crash1();
                //Crash2();
            }
        }
    }
