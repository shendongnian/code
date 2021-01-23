    		private void Button_Click(object sender, RoutedEventArgs e)
		{
			grid1.Visibility = Visibility.Hidden;
			br.Child = new UserControl2(this);
		}
		public void CloseView()
		{
			grid1.Visibility = Visibility.Visible;
			br.Child = null;
		}
