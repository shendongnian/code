	public class LifecycleCallbacks : Java.Lang.Object, IComponentCallbacks2
	{
		public void OnTrimMemory(TrimMemory level)
		{
			if (level == TrimMemory.UiHidden)
			{
				Console.WriteLine("Backgrounded...");
			}
		}
		
		public void OnConfigurationChanged(Configuration newConfig)
		{
		}
		public void OnLowMemory()
		{
		}
	}
