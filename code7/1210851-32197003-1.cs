    public class Content : INotifyPropertyChanged
	{
		private int _selector;
		public int Selector
		{
			get { return _selector; }
			set
			{
				_selector = value;
				OnPropertyChanged();
			}
		}
		public int Value1 { get; set; }
		public int Value2 { get; set; }
		public int Value3 { get; set; }
		public int Value4 { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	public class ViewModel
	{
		public Content ContentInstance { get; set; }
		public IEnumerable<int> AvailableValues { get { return Enumerable.Range(1, 4); } }
	}
