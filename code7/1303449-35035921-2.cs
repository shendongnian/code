        public class MainViewModel:BaseObservableObject
    {
        private Visibility _visibility;
        private ICommand _command;
        private Visibility _totalsVisibility;
        private double _totalValue;
        private double _columnWidth;
        public MainViewModel()
        {
            Visibility = Visibility.Collapsed;
            TotalsVisibility = Visibility.Collapsed;
            DataSource = new ObservableCollection<BaseData>(new List<BaseData>
            {
                new BaseData {Name = "Uncle Vania", Description = "A.Chekhov, play", Comments = "worth reading", Price = 25},
                new BaseData {Name = "Anna Karenine", Description = "L.Tolstoy, roman", Comments = "worth reading", Price = 35},
                new BaseData {Name = "The Master and Margarita", Description = "M.Bulgakov, novel", Comments = "worth reading", Price = 56},
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
            ColumnWidth = Visibility == Visibility.Visible ? 200d : 400d;
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
        public ObservableCollection<BaseData> ColumnCollection
        {
            get { return DataSource; }
        }
        public Visibility TotalsVisibility
        {
            get { return _totalsVisibility; }
            set
            {
                _totalsVisibility = value;
                OnPropertyChanged();
            }
        }
        public double TotalValue
        {
            get { return ColumnCollection.Sum(x => x.Price); }
        }
        public double ColumnWidth
        {
            get { return _columnWidth; }
            set
            {
                _columnWidth = value;
                OnPropertyChanged();
            }
        }
    }
    public class BaseData:BaseObservableObject
    {
        private string _name;
        private string _description;
        private string _comments;
        private int _price;
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
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }
    }
