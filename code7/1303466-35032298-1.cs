        class MainDataContext
    {
        private ICommand _viewCommand;
        private ICommand _deleteCommand;
        private ICommand _editCommand;
        public MainDataContext()
        {
            BaseModels = new ObservableCollection<BaseModel>
            {
                new BaseModel(EditCommand, DeleteCommand, ViewCommand){LastName = "Omar", FirstName = "Khayyam"},
                new BaseModel(EditCommand, DeleteCommand, ViewCommand){LastName = "Chekhov", FirstName = "Anton"},
                new BaseModel(EditCommand, DeleteCommand, ViewCommand){LastName = "Lau", FirstName = "Meir"},
            };
        }
        public ICommand ViewCommand
        {
            get { return _viewCommand ?? (_viewCommand = new RelayCommand<object>(View)); }
        }
        private void View(object obj)
        {
            
        }
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(Delete)); }
        }
        private void Delete(object obj)
        {
            
        }
        public ICommand EditCommand
        {
            get { return _editCommand ?? (_editCommand = new RelayCommand<object>(Edit)); }
        }
        private void Edit(object obj)
        {
            
        }
        public ObservableCollection<BaseModel> BaseModels { get; set; } 
    }
    public class BaseModel:BaseObservableObject
    {
        private string _firstName;
        private string _lastName;
        private readonly ICommand _editCommand;
        private readonly ICommand _deleteCommand;
        private readonly ICommand _viewCommand;
        public BaseModel(ICommand editCommand, ICommand deleteCommand, ICommand viewCommand)
        {
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
            _viewCommand = viewCommand;
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public ICommand EditCommand
        {
            get { return _editCommand; }
        }
        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
        }
        public ICommand ViewCommand
        {
            get { return _viewCommand; }
        }
    }
