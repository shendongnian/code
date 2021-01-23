	private SerialDisposable _serialDisposable = new SerialDisposable();
	
	private void btnGo_Click(object sender, RoutedEventArgs e)
	{
		_serialDisposable.Disposable =
			Observable
				.Interval(TimeSpan.FromSeconds(1.0))
				.Take(10)
				.Select(n => n + 20)
				.ObserveOnDispatcher()
				.Subscribe(n => txtblkCount.Text = n.ToString());
	}
	
