    public static class WindowUtils
    {
    	public static bool IsWindowOpen<T>(string name = "") where T : Window
    	{
    		return FindWindow<T>(name) != null;
    	}
    	public static T FindWindow<T>(string name = "") where T : Window
    	{
    		return FindWindow<T>(WindowsInternal, name) ?? FindWindow<T>(NonAppWindowsInternal, name);
    	}
    	private static T FindWindow<T>(Func<Application, WindowCollection> windowListAccessor, string name = "") where T : Window
    	{
    		bool matchName = !string.IsNullOrEmpty(name);
    		var windowList = windowListAccessor(Application.Current);
            for (int i = windowList.Count - 1; i >= 0; i--)
    		{
    			var window = windowList[i] as T;
    			if (window != null && (!matchName || window.Name == name)) return window;
    		}
    		return null;
    	}
    	private static readonly Func<Application, WindowCollection> WindowsInternal = GetWindowCollectionAccessor("WindowsInternal");
    	private static readonly Func<Application, WindowCollection> NonAppWindowsInternal = GetWindowCollectionAccessor("NonAppWindowsInternal");
    	private static Func<Application, WindowCollection> GetWindowCollectionAccessor(string propertyName)
    	{
    		var property = typeof(Application).GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    		return (Func<Application, WindowCollection>)Delegate.CreateDelegate(
    			typeof(Func<Application, WindowCollection>), property.GetMethod);
    	}
    }
