    using System;
    using System.Windows.Forms;
    namespace TestConsoleApp
    {
        public class Program
        {
            private const string Gui = "gui";
            private const string BackgroundProcess = "bgp";
            private static void LoadForm()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
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
                    case BackgroundProcess:
                        // Code that will perform task
                        break;
                }
            }
        }
    }
