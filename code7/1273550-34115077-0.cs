    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows;
    
    namespace Singleton
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        /// <remarks>
        /// 1. Change Build Action for App.xaml (right-click, Properties)
        ///     to Page from ApplicaitonDefinition
        /// 2. Go to project settings, and in the Debug tab, uncheck 
        ///     "Enable Visual Studio Hosting Process"
        /// </remarks>
        public partial class App : Application
        {
            [STAThread]
            public static void Main(string[] args)
            {
                bool bNew = true;
                using (Mutex mutex = new Mutex(true, "Singleton-GUID", out bNew)) // Replace string "Singleton_GUID" with one with a real GUID
                {
                    if(bNew)
                    {
                        new App().Run();
                    }
                    else
                    {
                        Process me = Process.GetCurrentProcess();
                        List<Process> processes = new List<Process>(Process.GetProcesses());
    
                        var matches = 
                            processes.FindAll((p) => 
                            {
                                return 
                                    string.Equals(p.ProcessName, me.ProcessName, StringComparison.InvariantCultureIgnoreCase) && 
                                    (p.Id != me.Id);
                            });
    
                        if (matches.Count == 1)
                        {
                            Process prior = matches[0];
                            if (prior.MainWindowHandle != IntPtr.Zero)
                            {
                                NativeMethods.ShowWindow(prior.MainWindowHandle, NativeMethods.SH_SHOW);
                            }
                        }
                    }
                }
            }
    
            private App()
            {
                InitializeComponent();
            }
        }
    
        public static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            public const int SH_SHOW = 5;
        }
    }
