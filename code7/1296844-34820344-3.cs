	public class MainViewModel : ViewModelBase
	{
		private ObservableCollection<string> _MyItems = new ObservableCollection<string>();
		public ObservableCollection<string> MyItems
		{
			get { return this._MyItems; }
			set { this._MyItems = value; RaisePropertyChanged(); }
		}
		private string _SelectedItem;
		public string SelectedItem
		{
			get { return this._SelectedItem; }
			set { this._SelectedItem = value; RaisePropertyChanged(); }
		}
		public ICommand ScrollCommand { get { return new RelayCommand<string>(OnScroll); } }
		private void OnScroll(string item)
		{
			this.ScrollHandler.ScrollTo(item);
		}
		private ListBoxScrollHandler _ScrollHandler = new ListBoxScrollHandler();
		public ListBoxScrollHandler ScrollHandler
		{
			get { return this._ScrollHandler;}
			set { this._ScrollHandler = value; RaisePropertyChanged(); }
		}
		public MainViewModel()
		{
			for (int i = 0; i < 1000; i++)
				this.MyItems.Add(i.ToString());
		}
	}
