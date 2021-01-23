    public class FreezableProxyClass : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new FreezableProxyClass();
        }
        public static readonly DependencyProperty ProxiedDataContextProperty = DependencyProperty.Register(
            "ProxiedDataContext", typeof(object), typeof(FreezableProxyClass), new PropertyMetadata(default(object)));
        public object ProxiedDataContext
        {
            get { return (object)GetValue(ProxiedDataContextProperty); }
            set { SetValue(ProxiedDataContextProperty, value); }
        }
    }
    public class MainNavigationViewModel : BaseObservableObject
    {
        private object _currentViewModel;
        private JobsViewModel _jobsViewModel;
        private List<LogModel> _logModels;
        private ICommand _showLogs;
        private ICommand _showJobs;
        public MainNavigationViewModel()
        {
            _jobsViewModel = new JobsViewModel();
            Init();
        }
        private void Init()
        {
            _jobsViewModel.JobModels = new ObservableCollection<JobModel>
            {
                new JobModel{Id = 1, Salary = "12k", Title = "Hw Engineer"},
                new JobModel{Id=2, Salary = "18k", Title = "Sw Engineer"},
                new JobModel{Id = 3, Salary = "12k", Title = "IT Engineer"},
                new JobModel{Id=4, Salary = "18k", Title = "QA Engineer"},
            };
            _logModels = new List<LogModel>
            {
                new LogModel{Id = 1, Salary = "12k", Title = "Hw Engineer", LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Pending"},
                new LogModel{Id = 1, Salary = "12k", Title = "Hw Engineer", LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Active"},
                new LogModel{Id = 1, Salary = "12k", Title = "Hw Engineer", LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Closed"},
                new LogModel{Id=2, Salary = "12k", Title = "Sw Engineer",   LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Pending"},
                new LogModel{Id=2, Salary = "12k", Title = "Sw Engineer",   LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Active"},
                new LogModel{Id=2, Salary = "12k", Title = "Sw Engineer",   LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Closed"},
                new LogModel{Id = 3, Salary = "12k", Title = "IT Engineer", LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Pending"},
                new LogModel{Id = 3, Salary = "12k", Title = "IT Engineer", LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Active"},
                new LogModel{Id = 3, Salary = "12k", Title = "IT Engineer", LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Closed"},
                new LogModel{Id=4, Salary = "12k", Title = "QA Engineer",   LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Pending"},
                new LogModel{Id=4, Salary = "12k", Title = "QA Engineer",   LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Active"},
                new LogModel{Id=4, Salary = "12k", Title = "QA Engineer",   LogTime = DateTime.Now.ToLocalTime(), LogEvent = "Closed"},
            };
            CurrentViewModel = _jobsViewModel;
        }
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(()=>CurrentViewModel);
            }
        }
        public ICommand ShowLogsCommand
        {
            get { return _showLogs ?? (_showLogs = new RelayCommand<JobModel>(ShowLogs)); }
        }
        private void ShowLogs(JobModel obj)
        {
            CurrentViewModel = new LogsViewModel
            {
                LogModels = new ObservableCollection<LogModel>(_logModels.Where(model => model.Id == obj.Id)),
            };
        }
        public ICommand ShowAllJobsCommand
        {
            get { return _showJobs ?? (_showJobs = new RelayCommand(ShowAllJobs)); }
        }
        private void ShowAllJobs()
        {
            CurrentViewModel = _jobsViewModel;
        }
    }
    public class LogsViewModel:BaseObservableObject
    {
        private ObservableCollection<LogModel> _logModels;
        public ObservableCollection<LogModel> LogModels
        {
            get { return _logModels; }
            set
            {
                _logModels = value;
                OnPropertyChanged();
            }
        }
    }
    public class LogModel : JobModel
    {
        private DateTime _logTime;
        private string _logEvent;
        public DateTime LogTime
        {
            get { return _logTime; }
            set
            {
                _logTime = value;
                OnPropertyChanged();
            }
        }
        public string LogEvent
        {
            get { return _logEvent; }
            set
            {
                _logEvent = value;
                OnPropertyChanged();
            }
        }
    }
    public class JobsViewModel:BaseObservableObject
    {
        private ObservableCollection<JobModel> _jobModels;
        public ObservableCollection<JobModel> JobModels
        {
            get { return _jobModels; }
            set
            {
                _jobModels = value;
                OnPropertyChanged();
            }
        }
    }
    public class JobModel:BaseObservableObject
    {
        private int _id;
        private string _title;
        private string _salary;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public string Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                OnPropertyChanged();
            }
        }
    }
