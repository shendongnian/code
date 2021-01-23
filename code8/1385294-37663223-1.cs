    	void Main()
	{
		var status = new Status();
		object locker = new object();
		
		status.PropertyChanged += Status_PropertyChanged;
		
		//
		// Long running job in a task
		//
		var task = new Task((s) => 
			{
			
				for(int i = 0; i < 1000; i++)
				{
                    Task.Delay(TimeSpan.FromSeconds(5)).Wait();
					//Thread.Sleep(5000);
					lock (locker)
					{
						status.Message = string.Format("Iteration: {0}", i);
					}
					
				}
				
				
			}, status);
		
		//
		// start and wait for the task to complete.  In a real application, you may end differently
		task.Start();
		task.Wait();
		
	}
	
	
	static void Status_PropertyChanged(object sender,
		PropertyChangedEventArgs e)
	{
	
		
		var s = sender as Status;
		
		if(s != null && string.Equals(e.PropertyName, "Message"))
		{
			Console.WriteLine( s.Message);
		}
	}
	
	
	public class Status : PropertyNotifier
	{
	
		private string _Message = string.Empty;
	
		public string Message
		{
			get { return _Message; }
			set { SetField(ref _Message, value); }
		}
	
	}
	
	public abstract class PropertyNotifier : INotifyPropertyChanged, INotifyPropertyChanging
	{
	public event PropertyChangingEventHandler PropertyChanging;
	public event PropertyChangedEventHandler PropertyChanged; // ? = new Delegate{};
	
		protected virtual void OnPropertyChanged(string propertyName)
		{
	
			PropertyChangedEventHandler handler = PropertyChanged;
			
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
		
		protected virtual void OnPropertyChanging(string propertyName)
		{
			PropertyChangingEventHandler handler = PropertyChanging;
			
			if (handler != null) handler(this, new PropertyChangingEventArgs(propertyName));
		}
		
		protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			OnPropertyChanging(propertyName);
			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}
	
	
	}
