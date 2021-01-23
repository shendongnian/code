	public static class FrameworkElementExtensions
	{
		public static void BeginInvoke(this DispatcherObject element, Action action, DispatcherPriority priority = DispatcherPriority.ApplicationIdle)
		{
			element.Dispatcher.BeginInvoke(priority, new Action(async () =>
			{
				await Task.Yield();
				action();
			}));
		}
	}
