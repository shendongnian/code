    internal class App : Application
    {
        [STAThread]
        public static int Main(string[] args)
        {
            App app = new App();
            // Setup your application as you want before running it
            return app.Run(new MainWindow());
        }
        public App()
        {
            // (Optional) Load your application resources file (which has a "Page" build action, not "ApplicationDefinition",
            // and a root node of type "ResourceDictionary", not "Application")
            Resources = (ResourceDictionary)Application.LoadComponent(new Uri("/MyAssemblyName;component/Resources.xaml", UriKind.Relative));
        }
    }
