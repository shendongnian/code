    public MyViewModel()
    {
        Lines = new ObservableCollection<String>();
    }
    private ObservableCollection<String> _lines;
    public ObservableCollection<String> Lines
    {
        get { return _lines; }
        protected set {
            _lines = value;
            UpdateText();
            _lines.CollectionChanged += _lines_CollectionChanged;
            OnPropertyChanged("Lines");
        }
    }
    private void UpdateText()
    {
        Text = String.Join("\n", Lines);
    }
    private void _lines_CollectionChanged(object sender, 
        System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        UpdateText();
    }
    private string _text;
    public String Text {
        get { return _text; }
        protected set {
            _text = value;
            OnPropertyChanged("Text");
        }
    }
