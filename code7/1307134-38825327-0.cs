	public class View
    {
        private readonly Dictionary<string, Dictionary<string, object>> _views = new Dictionary<string, Dictionary<string, object>>();
        private static readonly View _instance = new View();
        public static View State => _instance;
        public Dictionary<string, object> this[string viewKey]
        {
            get
            {
                if (_views.ContainsKey(viewKey))
                {
                    return _views[viewKey];
                }
                return null;
            }
            set
            {
                _views[viewKey] = value;
            }
        }
        public Dictionary<string, object> this[Type viewType]
        {
            get
            {
                return this[viewType.FullName];
            }
            set
            {
                this[viewType.FullName] = value;
            }
        }
    }
	public class MyClassWithScrollViewer
	{
		private void OnUnloaded(object sender, EventArgs e)
		{
			View.State[typeof(MyClassWithScrollViewer)] = new Dictionary<string, object>()
			{
				{ "ScrollViewer_VerticalOffset", scrollViewer.VerticalOffset, }
				{ "ScrollViewer_HorizontalOffset", scrollViewer.HorizontalOffset, }
				// Additional fields here
			};
		}
		
		private void OnLoaded(object sender, EventArgs e)
		{
			var persisted = View.State[typeof(MyClassWithScrollViewer)];
			if (persisted != null)
			{
				scrollViewer.ScrollToVerticalOffset(persisted[ScrollViewer_VerticalOffset] as double);
				scrollViewer.ScrollToHorizontalOffset(persisted[ScrollViewer_HorizontalOffset] as double);
				// Additional fields here
			}
		}
	}
