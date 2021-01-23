     public class MainViewModel:BaseObservableObject
    {
        public MainViewModel()
        {
            Titles = new ObservableCollection<Model>(new List<Model>
            {
                new Model {Title = "War and Peace, Tolstoy"},
                new Model {Title = "Anna Karenine, Tolstoy"},
                new Model {Title = "Uncle Vanya, Chekhov"},
            });
        }
        public ObservableCollection<Model> Titles { get; set; }
    }
    public class Model:BaseObservableObject
    {
        private ICommand _changeIsReadedStatusCommand;
        private bool _isReaded;
        private string _title;
        public Model()
        {
            IsReaded = false;
        }
        public bool IsReaded
        {
            get { return _isReaded; }
            set
            {
                _isReaded = value;
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
        public ICommand ChangeIsReadedStatusCommand
        {
            get
            {
                return _changeIsReadedStatusCommand ??
                       (_changeIsReadedStatusCommand = new RelayCommand(ChangeIsReadedStatus));
            }
        }
        private void ChangeIsReadedStatus()
        {
            IsReaded = !IsReaded;
        }
    }
