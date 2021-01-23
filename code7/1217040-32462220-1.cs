    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new AppContext());
        }
    }
    class AppContext : ApplicationContext
    {
        public AppContext()
        {
            // Do Stuff
        }
    }
