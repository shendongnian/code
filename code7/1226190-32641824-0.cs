    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
     
    public class DetectDebugger
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);
     
        public static void Main()
        {
            bool isDebuggerPresent = false;
            CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);
     
            Console.WriteLine("Debugger Attached: " + isDebuggerPresent);
            Console.ReadLine();
        }
    }
