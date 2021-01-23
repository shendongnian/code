    private ObservableCollection<Family> families; 
    public ObservableCollection<Family> Families
    {
        get { return families; }
        set
        {
            families = value;
            NotifyPropertyChanged("Families");
        }
    }
