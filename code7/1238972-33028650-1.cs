    using System;
    using System.Windows.Forms;
    
    namespace Sample
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                 
                //create a controller and Pass an instance of your application main form
                ApplicationController controller = 
                    new ApplicationController(new YourApplicationMainForm());
                //Run application
                controller.Run(Environment.GetCommandLineArgs());
            }
        }
    }
