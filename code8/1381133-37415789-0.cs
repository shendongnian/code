    public partial class App : TestApp
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.StartupUri = new System.Uri("MainWindow.xaml", System.UriKind.Relative);
            app.Run();
        }
    }
