	private SerialDisposable _serialDisposable = new SerialDisposable();
	
	protected void LoadFile(object sender, EventArgs e)
	{
		_serialDisposable.Disposable =
			Observable
				.Interval(TimeSpan.FromSeconds(60.0))
				.Subscribe(n =>
				{
					string path = UniquePath();
					File.Delete(path)
	            });
	}
