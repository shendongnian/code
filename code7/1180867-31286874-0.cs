    private ObservableCollection<Student> _Students;
    public ObservableCollection<Student> Students
    {
        get { return _Students; }
        set
        {
            _Students = value;
            //Notify property changed stuff.
            OnPropertyChanged();
        }
    }
