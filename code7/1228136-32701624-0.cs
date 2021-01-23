    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var argumentsInfo = BuildArgumentsInfo(e.Args);
            var viewModel = new MainWindowViewModel(argumentsInfo);
            var window = new MainWindow(viewModel);
            window.Show();
        }
        private string BuildArgumentsInfo(string[] args)
        {
            return args.Any()
                ? args.Aggregate((arg1, arg2) => arg1 + " " + arg2)
                : "No arguments";
        }
    }
