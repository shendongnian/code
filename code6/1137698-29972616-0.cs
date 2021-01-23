    public class UserViewModel : ViewModelBase
    {
        private User _originalModel;
        private User _model;
        public User Model
        {
            get { return _model; }
            set
            {
                _model = value;
                _originalModel = _model;
            }
        }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public UserViewModel()
        {
            EditCommand = new DelegateCommand(OnEditCommandExecuted);
            CancelCommand = new DelegateCommand(OnCancelCommandExecuted);
            SaveCommand = new DelegateCommand(SaveCommandExecuted);
        }
        private void SaveCommandExecuted(object obj)
        {
            _originalModel = _model;
        }
        private void OnCancelCommandExecuted(object obj)
        {
            _model = _originalModel;
        }
        private void OnEditCommandExecuted(object obj)
        {
            _originalModel = _model;
        }
        public string FirstName
        {
            get { return Model.FirstName; }
            set
            {
                if (value == Model.FirstName) return;
                Model.FirstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return Model.LastName; }
            set
            {
                if (value == Model.LastName) return;
                Model.LastName = value;
                OnPropertyChanged();
            }
        }
    }
