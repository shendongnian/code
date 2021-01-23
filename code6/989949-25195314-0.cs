    public static class StateManager 
    {
	public static void Process(Action action) {
		IsBusy = true;
		Application.Current.Dispatcher.Invoke(action, System.Windows.Threading.DispatcherPriority.Background);
		IsBusy = false;
	}
	private static bool _IsBusy;
	public static bool IsBusy {
		get {
			return _IsBusy;
		}
		set {
			if (_IsBusy != value) {
				_IsBusy = value;
				IsBusyChange(null, null);
			}
		}
	}
	public delegate void IsBusyHandler(object sender, EventArgs e);
	public static event IsBusyHandler IsBusyChange;
