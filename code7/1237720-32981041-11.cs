	// record model
	public class Record
	{
		public string name {get; set;}
		public string phone { get; set; }
		public int countryCode {get; set;}
	}
	// record view model
	public class RecordViewModel : ViewModelBase
	{
		private Record record = new Record();
		public string name
		{
			get { return record.name; }
			set
			{
				record.name = value;
				RaisePropertyChanged("name");
			}
		}
		public string phone
		{
			get { return record.phone; }
			set
			{
				record.phone = value;
				RaisePropertyChanged("phone");
			}
		}
		private Country _country;
		public Country country
		{
			get { return _country; }
			set
			{
				_country = value;
				record.countryCode = value.code;
				RaisePropertyChanged("country");
			}
		}
	}
	public class Country : ViewModelBase
	{
		private string _name;
		public string name
		{
			get { return _name; }
			set
			{
				_name = value;
				RaisePropertyChanged("name");
			}
		}
		private int _id;
		public int id
		{
			get { return _id; }
			set
			{
				_id = value;
				RaisePropertyChanged("id");
			}
		}
		private int _code;
		public int code
		{
			get { return _code; }
			set
			{
				_code = value;
				RaisePropertyChanged("code");
			}
		}
		public override string ToString()
		{
			return _name;
		}
	}
	public class GridModel : ViewModelBase
	{
		public ObservableCollection<RecordViewModel> customers { get; set; }
		public List<Country> countries { get; set; }
		public GridModel()
		{
			customers = new ObservableCollection<RecordViewModel>();
			countries = new List<Country> { new Country { id = 1, name = "England", code = 44 }, new Country { id = 2, name = "Germany", code = 49 },
        new Country { id = 3, name = "US", code = 1}, new Country { id = 4, name = "Canada", code = 11 }};
		}
		private RecordViewModel _selectedRow;
		public RecordViewModel SelectedRow
		{
			get
			{
				return _selectedRow;
			}
			set
			{
				_selectedRow = value;
				Debug.Print("Datagrid selection changed");
				RaisePropertyChanged("SelectedRow");
			}
		}
	}
	// this is needed for when you need to bind something that isn't part of the visual tree (i.e. your combobox dropdowns)
	// see http://www.thomaslevesque.com/2011/03/21/wpf-how-to-bind-to-data-when-the-datacontext-is-not-inherited/ for details
	public class BindingProxy : Freezable
	{
		#region Overrides of Freezable
		protected override Freezable CreateInstanceCore()
		{
			return new BindingProxy();
		}
		#endregion
		public object Data
		{
			get { return (object)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		// Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DataProperty =
			DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
	}
