	public class MyClass : ViewModelBase, IDisposable
	{
		static HashSet<MyClass> Instances = new HashSet<MyClass>();
		public MyClass()
		{
			Instances.Add(this);		// register
		}
		// dispose object to de-register 
		public void Dispose()
		{
			Instances.Remove(this);
		}
		private static void ReportAvailability()
		{
			foreach (var instance in Instances)
				instance.Conn = NetworkStatus.IsAvailable;
		}
		private bool _conn;
		public bool Conn
		{
			get { return _conn; }
			set
			{
				if (_conn != value)
					_conn = value; RaisePropertyChanged();
			}
		}
	}
