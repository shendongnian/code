	public class Example : INotifyPropertyChanged
	{
		private MyClass _item;
		private PropertyChangedNotifier<Example> _notifier;
		public Example()
		{
			_notifier = new PropertyChangedNotifier<Example>( this );
		}
		public event PropertyChangedEventHandler PropertyChanged
		{
			add { _notifier.PropertyChanged += value; }
			remove { _notifier.PropertyChanged -= value; }
		}
		public MyClass Item
		{
			get
			{
				return _item;
			}
			protected set
			{
				_item = value;
				OnPropertyChanged("Item");
			}
		}
		[DependsOn( "Item" )]
		public object Field
		{
			get
			{
				return _item.Field;
			}
		}
		protected void OnPropertyChanged(string propertyName)
		{
			_notifier.OnPropertyChanged( propertyName );
		}
	}
