        public class MainViewModel:BaseObservableObject
    {
        private Visibility _visibility;
        private ICommand _command;
        public MainViewModel()
        {
            Visibility = Visibility.Collapsed;
            DataSource = new ObservableCollection<BaseData>(new List<BaseData>
            {
                new BaseData {Name = "Uncle Vania", Description = "A.Chekhov, play", Comments = "worth reading"},
                new BaseData {Name = "Anna Karenine", Description = "L.Tolstoy, roman", Comments = "worth reading"},
                new BaseData {Name = "The Master and Margarita", Description = "M.Bulgakov, novel", Comments = "worth reading"},
            });
        }
        public ICommand Command
        {
            get
            {
                return _command ?? (_command = new RelayCommand(VisibilityChangingCommand));
            }
        }
        private void VisibilityChangingCommand()
        {
            Visibility = Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
        public ObservableCollection<BaseData> DataSource { get; set; }
        public Visibility Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }
    }
    public class BaseData:BaseObservableObject
    {
        private string _name;
        private string _description;
        private string _comments;
        public virtual string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public virtual object Description
        {
            get { return _description; }
            set
            {
                _description = (string) value;
                OnPropertyChanged();
            }
        }
        public string Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                OnPropertyChanged();
            }
        }
    }
