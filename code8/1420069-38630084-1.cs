    namespace HungProcessName
    {
        using System.Runtime.InteropServices;
        using System.Threading;
        using System.Diagnostics;
        using System;
    
        class Program
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")]
            private static extern IntPtr GhostWindowFromHungWindow(IntPtr hwnd);
            [DllImport("user32.dll")]
            private static extern IntPtr HungWindowFromGhostWindow(IntPtr hwnd);
            [DllImport("user32.dll")]
            private static extern bool IsHungAppWindow(IntPtr hwnd);
            [DllImport("user32.dll")]
            private static extern uint GetWindowThreadProcessId(IntPtr hwnd, out uint procId);
    
            static void Main(string[] args)
            {
                while (true)
                {
                    var hwnd = GetForegroundWindow();
                    Console.WriteLine("Foreground window: {0}", hwnd);
                    if (IsHungAppWindow(hwnd))
                    {
                        var hwndReal = HungWindowFromGhostWindow(hwnd);
                        uint procId = 0;
                        GetWindowThreadProcessId(hwndReal, out procId);
                        if (procId > 0)
                        {
                            Process proc = null;
                            try { proc = Process.GetProcessById((int)procId); }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Could not get proces with Id '{0}': {1}", procId, ex);
                            }
                            if (proc != null)
                            {
                                Console.WriteLine("Ghost hwnd: {0}, Real hwnd: {1}. ProcessId: {2}, Proccess name: {3}",
                                    hwnd, hwndReal, procId, proc.ProcessName);
                            }
                        }
                    }
                    Thread.Sleep(100);
                }
            }
        }
    }
