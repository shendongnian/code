	public class EmployeesListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<EmployeeDetailsViewModel> _employees;
        public EmployeesListViewModel()
        {
            _employees = new ObservableCollection<EmployeeDetailsViewModel>();
            _employees.Add(new EmployeeDetailsViewModel() { BeginDate = DateTime.Now });
            _employees.Add(new EmployeeDetailsViewModel() { BeginDate = DateTime.Now.AddDays(1) });
        }
		
		public ObservableCollection<EmployeeDetailsViewModel> Employees
        {
            get { return _employees; }
        }	
	}
	
	
	public class EmployeeDetailsViewModel : INotifyPropertyChanged
    {
        DispatcherTimer _timer = null;
        public EmployeeDetailsViewModel()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) => { OnPropertyChanged("BeginDate"); };
            _timer.Start();
        }
        public void StopTimer()
        {
            _timer.Stop();
        }
        private DateTime _beginDate;
        public DateTime BeginDate
        {
            get { return _beginDate; }
            set
            {
                _beginDate = value;
                OnPropertyChanged("BeginDate");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, e);
            }
        }
	}
	
	public class ColorBeginDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                                                    object parameter, CultureInfo culture)
        {
            try
            {
                if (DateTime.Now.Second % 2 == 0)
                    return Brushes.Transparent;
                else
                    return Brushes.Orange;
            }
            catch (Exception)
            {
                return Brushes.Transparent;
            }
        }
        public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            return "not implemented";
        }
    }
