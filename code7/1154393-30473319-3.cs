    using System;
    using System.Windows.Forms;
    
    namespace testApp
    {
        public static class AppSettings // May as well make the class static 
        {
            public static int appState { get; set; }
            public static bool[] stepsCompleted { get; set; }
    
            static AppSettings() // Static constructor
            {
                appState = 0;
                stepsCompleted = new[] { false, false, false, false, false };
            }
        }
    
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
                Application.Run(new gameScreen());
            }
        }
    }
