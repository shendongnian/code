	private void button2_click(object sender, RoutedEventArgs e)
	{
		Window parentWindow = Application.Current.MainWindow;
		if (parentWindow.GetType() == typeof(MainWindow))
		{
			(parentWindow as MainWindow).UC1.Visibility = Visibility.Collapsed;
			(parentWindow as MainWindow).UC2.Visibility = Visibility.Visible;
		}
	}
