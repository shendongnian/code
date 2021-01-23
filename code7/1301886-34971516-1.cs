   	public class MyListType
	{
		// some data
	}
	public class MyModel
	{
		public IList<MyListType> MyListItems { get; set; }
		
		public MyModel()
		{
			this.MyListItems = new ObservableCollection<MyListType>();
		}
	}
	public class MyListTypeViewModel : ViewModelBase
	{
		public MyListType Model {get; set;}
		// INPC properties go here
	}
	public class MyViewModel
	{
		public IList<MyListTypeViewModel> MyListItemViewModels { get; set; }
		public MyViewModel(MyModel model)
		{
			(model.MyListItems as INotifyCollectionChanged).CollectionChanged += OnListChanged;
			// todo: create initial view models for any items already in MyListItems
		}
		private void OnListChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			// create any new elements
			if (e.NewItems != null)
				foreach (MyListType item in e.NewItems)
					this.MyListItemViewModels.Add(new MyListTypeViewModel{Model = item});
			// remove any new elements
			if (e.OldItems != null)
				foreach (MyListType item in e.OldItems)
					this.MyListItemViewModels.Remove(
						this.MyListItemViewModels.First(x => x.Model == item)
					);
		}
