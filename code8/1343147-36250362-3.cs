	private void btn_Click(object sender, RoutedEventArgs e)
	{
		popup.ItemsSource = FavoriteProductCollectionViewModelIns;
		popup.Visibility = Visibility.Visible;
		popup.IsOpen = true;
	}
