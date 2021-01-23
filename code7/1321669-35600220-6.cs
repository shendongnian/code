    public partial class App : Application
    {
         protected override void OnStartup(StartupEventArgs e)
        {
                base.OnStartup(e);
                MainWindow app = new MainWindow();
                ProductViewModel context = new ProductViewModel();
                app.DataContext = context;
                app.Show();
         }
    }
