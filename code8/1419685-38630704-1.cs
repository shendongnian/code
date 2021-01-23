    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new MyApp().Run(args);
          
        }
    class MyApp : WindowsFormsApplicationBase
    {
        protected override void OnCreateSplashScreen()
        {
            this.SplashScreen = new StartupSplash();
        }
        protected override void OnCreateMainForm()
        {
            Boolean result = false;
            using (var connectiontest = new SqlConnection("myConnectionString"))
                try
                {
                    connectiontest.Open();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }
            // pause not needed while checking for db connection as that takes its own amount of time to complete.
           
            if (result)
            {
                System.Threading.Thread.Sleep(3000); //pause moved here to give the splash some time on screen if db connection available
                this.MainForm = new MainWindow();
            }
            else
            {
                MessageBox.Show("Unable to connect to the database");
                
                Environment.Exit(1); // shuts down the program if database connection not avaliable.
            }
        }
    }
