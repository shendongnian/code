    public partial class App : Application
    {
        public static runtimeObject runtime { get; set; };
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Startup
            Window main = new MainWindow();
            main.Show();
            //Bind Commands
            Classes.MyCommands.BindCommandsToWindow(main);
            // Create runtime objects
            // Assign to accessible property.
            runtime = new runtimeObject();            
        }
        public static explicit operator App(Application v)
        {
            throw new NotImplementedException();
        }
    }
