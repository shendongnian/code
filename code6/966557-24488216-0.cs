	public class KeyboardViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<ToolItemViewModel> _toolItems;
		public ObservableCollection<ToolItemViewModel> ToolItems
		{
			get { return _toolItems; }
			set
			{
				_toolItems = value;
				OnPropertyChanged("ToolItems");
			}
		}
		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
		public ToolItemViewModel AddToolItem()
		{
			ToolItemViewModel item = new ToolItemViewModel();
			ToolItems.Add(item);
			return item;
		}
	}
	public class ToolItemViewModel : INotifyPropertyChanged
	{
		private string _tooltip;
		public string Tooltip
		{
			get { return _tooltip; }
			set
			{
				_tooltip = value;
				OnPropertyChanged("Tooltip");
			}
		}
		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
