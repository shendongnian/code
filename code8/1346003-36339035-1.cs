    using System;
    using System.Windows.Forms;
    namespace TestConsoleApp
    {
        public class Program
        {
            private const string GuiWinForm = "gui";
            private const string GuiConsole = "console";
            private const string BackgroundProcess = "bgp";
            private const string Cmd = "cmd";
            [DllImport("kernel32", SetLastError = true)]
            private static extern bool AttachConsole(int dwProcessId);
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll", SetLastError = true)]
            private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
            private static void LoadForm()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool AllocConsole();
            private static void CreateNewConsole()
            {
                AllocConsole();
                Console.WriteLine("New Console App");
                Console.ReadLine();
            }
            private static void LoadConsole()
            {
                // *** Gets Command Window if it is already open ***
                var ptr = GetForegroundWindow();
                int u;
                GetWindowThreadProcessId(ptr, out u);
                var process = Process.GetProcessById(u);
                if (process.ProcessName == Cmd)
                    AttachConsole(process.Id);
                // *** Creates a new Command Prompt if the foreground is not a console ***
                else
                    CreateNewConsole();
            }
            // Get the args from either command line or from config file
            [STAThread]
            private static void Main(string[] args)
            {
                var mode = args.Length > 0 ? args[0] : Gui;
                switch (mode)
                {
                    case Gui:
                        LoadForm();
                        break;
                    /* If for some reason you just cannot stand the 
                    idea of using a winform for this task/process */
                    case GuiConsole:
                         LoadConsole();
                         break;
                    case BackgroundProcess:
                        // Code that will perform task
                        break;
                }
            }
        }
    }
