    using System;
    
    namespace Sample
    {
        public class Startup
        {
            [STAThread]
            public static void Main(string[] args)
            {
                SingleInstanceApplicationWrapper wrapper = new SingleInstanceApplicationWrapper();
                wrapper.Run(args);
            }
        }
    
        public class SingleInstanceApplicationWrapper :
            Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
        {
            public SingleInstanceApplicationWrapper()
            {
                // Enable single-instance mode.
                this.IsSingleInstance = true;
            }
    
            // Create the WPF application class.
            private WpfApp app;
            protected override bool OnStartup(
                Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
            {
    
    
                app = new WpfApp();
                app.Run();
    
                return false;
            }
    
            // Direct multiple instances
            protected override void OnStartupNextInstance(
                Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs e)
            {
                if (e.CommandLine.Count > 0)
                {
                    ((MainWindow)app.MainWindow).openFile(e.CommandLine[0]);
                }
            }
        }
    
        public class WpfApp : System.Windows.Application
        {
            protected override void OnStartup(System.Windows.StartupEventArgs e)
            {
                base.OnStartup(e);
    
                // Load the main window.
                MainWindow main = new MainWindow();
                this.MainWindow = main;
                main.Show();
    
                // Load the document that was specified as an argument.
                if (e.Args.Length > 0) main.openFile(e.Args[0]);
            }
    
    
    
        }   
    }
