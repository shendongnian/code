    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IoC.Configure(true);
         
            StartupUri = new Uri("Views/MainWindowView.xaml", UriKind.Relative);
            base.OnStartup(e);
        }
    }
