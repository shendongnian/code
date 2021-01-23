    public partial class App : TestApp
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
            app.Run();
        }
    }
