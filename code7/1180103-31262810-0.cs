	public class TestCombo : INotifyPropertyChanged
	{
		private int someData;
		public int SomeData 
		{
			get { return someData; }
			set { someData = value; RaisePropertyChanged("SomeData"); }
		}
		
		private SingleAssignmentDisposable _subscription = new SingleAssignmentDisposable();
		
		public void Begin(int input)
		{
			_subscription.Disposable =
				Observable
					.Interval(TimeSpan.FromSeconds(1.0))
					.Select(x => input - (int)x)
					.Take(input)
					.ObserveOnDispatcher()
					.Subscribe(x => this.SomeData = x);
		}
	
		public event PropertyChangedEventHandler PropertyChanged;
		private void RaisePropertyChanged (string info)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(info));
		}
	}
