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
                    Process.Start(Assembly.GetEntryAssembly().Location);
                    ApplicationRecoveryFinished(true);
                    return 0;
                });
    
                var interval = 100U;
                var flags = 0U;
    
                RegisterApplicationRecoveryCallback(callback,IntPtr.Zero,interval,flags);
            }
    
            static void Main(string[] args)
            {
                RegisterForRecovery();
    
                for (var i = 3; i > 0; i--)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("Crash in {0}", i);
                    Thread.Sleep(1000);
                }
                Environment.FailFast("Crash.");
            }
        }
    }
