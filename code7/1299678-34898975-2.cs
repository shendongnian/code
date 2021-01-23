    ObservableCollection<string> _SelectedTexts; 
    public ObservableCollection<string> SelectedTexts
    {
        get { return _SelectedTexts; }
        set
        {
           _SelectedTexts; = value;
           RaisePropertyChanged("SelectedTexts");
        }
    } 
    public YourViewModelConstructor
    {
               
        SelectedTexts = new ObservableCollection<string>();
    }
