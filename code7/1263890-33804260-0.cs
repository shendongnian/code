	public class EnhancedObservableCollection<T> : ObservableCollection<T>
		where T : INotifyPropertyChanged
	{
		public EnhancedObservableCollection(bool isCollectionChangedOnChildChange)
		{
			IsCollectionChangedOnChildChange = isCollectionChangedOnChildChange;
		}
		public EnhancedObservableCollection(List<T> list, bool isCollectionChangedOnChildChange) : base(list)
		{
			IsCollectionChangedOnChildChange = isCollectionChangedOnChildChange;
		}
		public EnhancedObservableCollection(IEnumerable<T> collection, bool isCollectionChangedOnChildChange) : base(collection)
		{
			IsCollectionChangedOnChildChange = isCollectionChangedOnChildChange;
		}
		public bool IsCollectionChangedOnChildChange { get; set; }
		public event EventHandler<string> ChildChanged;
		protected override void RemoveItem(int index)
		{
			var item = Items[index];
			item.PropertyChanged -= ItemOnPropertyChanged;
			base.RemoveItem(index);
		}
		private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
		{
			var handler = ChildChanged;
			if (handler != null)
			{
				handler(this, propertyChangedEventArgs.PropertyName);
			}
			if (IsCollectionChangedOnChildChange)
			{
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace));
			}
		}
		protected override void InsertItem(int index, T item)
		{
			base.InsertItem(index, item);
			item.PropertyChanged += ItemOnPropertyChanged;
		}
	}
