	private EventHandler eventHandler = 
								new EventHandler(async (s, e) => await FooAsync(s, e));
								
	public async void SomeOtherEventHandler()
	{
		var m = new M();
		m.X += eventHandler;
		m.OnFoo();
		m.X -= eventHandler;
		m.OnFoo();
	}
	
	public async Task FooAsync(object sender, EventArgs e)
	{
		await Task.Delay(1000);
		Debug.WriteLine("Yay event handler");
	}
	
	public class M
	{
		public event EventHandler X;
		public void OnX()
		{
			// If you're using C#-6, then X?.Invoke(null, EventArgs.Empty);
			
			var localX = X;
			if (localX != null)
				localX(null, EventArgs.Empty);
		}
	}
