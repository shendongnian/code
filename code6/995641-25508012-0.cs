    public partial class App {
      protected override void OnStartup(StartupEventArgs e) {
        base.OnStartup(e);
        var container = CreateContainer();
        var viewModel = container.Resolve<RootViewModel>();
        var window = new MainWindow { DataContext = viewModel };
        window.Show();
      }
    }
