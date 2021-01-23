    using System;
    namespace ConsoleApplication
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                RunApplication();
            }
    
            private static void RunApplication()
            {
                var application = new System.Windows.Application();
                application.Run();
            }
        }
    }
