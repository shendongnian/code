    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UsersWindow window = new UsersWindow();
            var ViewModel = new UserListViewModel();
            window.DataContext = ViewModel;
            window.Show();
        }
    }
