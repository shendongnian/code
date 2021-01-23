    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow
                { DataContext = await MainWindowViewModel.Create() };
            //next line will be executed after "Create" method will complete
            mainWindow.Show();
        }
    }
