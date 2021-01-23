    public partial class MainWindow : Window
    {
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (App.Current as App).AppLauncher.Close();
        }
    }
