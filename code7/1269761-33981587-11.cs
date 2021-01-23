        public class MainViewModel:BaseObservableObject
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<ItemDataContext>(new List<ItemDataContext>
            {
                new ItemDataContext{ButtonContent = "A", X = 1.0, Y = 1.0},
                new ItemDataContext{ButtonContent = "B", X = 1.0, Y = 1.0},
                new ItemDataContext{ButtonContent = "C", X = 1.0, Y = 1.0},
                new ItemDataContext{ButtonContent = "D", X = 1.0, Y = 1.0},
            });
        }
        public ObservableCollection<ItemDataContext> Items { get; set; }
    }
    public class ItemDataContext:BaseObservableObject
    {
        private ICommand _buttonCommand;
        private object _buttonContent;
        private double _x;
        private double _y;
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged();
            }
        }
        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged();
            }
        }
        public ICommand ButtonCommand
        {
            get { return _buttonCommand ?? (_buttonCommand = new DelegateCommand(Target)); }
        }
        public object ButtonContent
        {
            get { return _buttonContent; }
            set
            {
                _buttonContent = value;
                OnPropertyChanged();
            }
        }
        private void Target(object obj)
        {
            X += 0.2;
            Y += 0.2;
        }
    }
