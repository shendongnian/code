    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint GetCurrentThreadId();
    
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenThread(uint desiredAccess, bool inheritHandle, uint threadId);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CancelSynchronousIo(IntPtr threadHandle);
        
        static bool CancelSynchronousIo(uint threadId)
        {
            // GENERIC_WRITE, Non-inheritable
            var threadHandle = OpenThread(0x40000000, false, (uint)threadId);
            var ret = CancelSynchronousIo(threadHandle);
    
            CloseHandle(threadHandle);
    
            return ret;
        }
    
        static void Main(string[] args)
        {
            uint threadId = 0;
    
            using (var threadStarted = new AutoResetEvent(false))
            {
                var thread = new Thread(() =>
                {
                    try
                    {
                        Thread.BeginThreadAffinity();
                        threadId = GetCurrentThreadId();
    
                        threadStarted.Set();
    
                        // will throws System.OperationCanceledException
                        Console.ReadLine();
                    }
                    finally
                    {
                        Thread.EndThreadAffinity();
                    }
                });
    
                thread.Start();
    
                threadStarted.WaitOne();
            }
    
            Debugger.Break();
    
            CancelSynchronousIo(threadId);
        }
    }
