    public static T IsWindowOpen<T>(string name = null) where T : Window
    {
        var windows = Application.Current.Windows.OfType<T>();
        return string.IsNullOrEmpty(name) ? windows.FirstOrDefault() : windows.FirstOrDefault(w => w.Name.Equals(name));
    }
    private void HAZEDashboard_Loaded(object sender, RoutedEventArgs e)
    {
        var window = IsWindowOpen<pgLogin>();
        if (window != null)
        {
            var credentials =  window.txtEmailAddress.Text.ToString();
            window.Close();
        }
    }
