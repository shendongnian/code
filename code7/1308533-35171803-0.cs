    public class CustomWindow : Window
    {
        protected void MinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
 
        protected void RestoreClick(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }
 
        protected void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
