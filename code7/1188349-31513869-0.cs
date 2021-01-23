    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    
    namespace Test
    {
        static class Program
        {
            [DllImport("kernel32.dll")]
            static extern bool AttachConsole(int dwProcessId);
            private const int ATTACH_PARENT_PROCESS = -1;
    
            [STAThread]
            static void Main()
            {
                AttachConsole(ATTACH_PARENT_PROCESS);
                Console.WriteLine("This will show on console.");
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                Application.Run(new Form1());
            }
        }
    }
