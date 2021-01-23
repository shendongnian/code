    public class MainViewModel
	{
		ObservableCollection<SimpleModel> _list = new ObservableCollection<SimpleModel>();
        public ObservableCollection<SimpleModel> List
		{
			get { return _list; }
		}
		public MainViewModel()
		{
			_list.Add(new SimpleModel() { Name = "obj1" });
			_list.Add(new SimpleModel() { Name = "obj2" });
			_list.Add(new SimpleModel() { Name = "obj3" });
		}
	}
