    public static bool IsWindowOpen<T>(string name = "") where T : Window
    {
    	return Application.Current.Dispatcher.Invoke(() => string.IsNullOrEmpty(name)
    	   ? Application.Current.Windows.OfType<T>().Any()
    	   : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name)));
    }
