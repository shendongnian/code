    public class Rule : INotifyPropertyChanged
    {
        private ObservableCollection<RuleTag> elseIf = new ObservableCollection<RuleTag>();
        private RuleTag _else;
        private CompositeCollection children = new CompositeCollection();
        public RuleTag IF { get; set; }
        public RuleTag Else
        {
            get { return _else; }
            set
            {
                _else = value;
                OnPropertyChanged("Children");
            }
        }
        public ObservableCollection<RuleTag> ElseIf
        {
            get { return elseIf; }
        }
        public CompositeCollection Children
        {
            get
            {
                children.Clear();
                children.Add(new CollectionContainer() { Collection = IF.Children });
                children.Add(new CollectionContainer() { Collection = ElseIf });
                if (Else != null)
                    children.Add(Else);
                return children;
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
