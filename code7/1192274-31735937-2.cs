	public ObservableCollection<int> items { get; set; } = new ObservableCollection<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	private async void MyListView_Loaded(object sender, RoutedEventArgs e)
	{
	    foreach (var item in items)
	        MyListView.Items.Add(item);
	    await Task.Delay(1000); //wait for animation
	    MyListView.SetBinding(ItemsControl.ItemsSourceProperty, new Binding() { Source = this, Path = new PropertyPath("items"), Mode = BindingMode.TwoWay });
	}
