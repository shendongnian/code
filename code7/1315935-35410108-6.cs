    private Thickness _pageThickness;
    public Thickness PageThickness
    {
    get
     {
       return _pageThickness;
     }
    set
     {
      _pageThickness = value;
      NotifyPropertyChanged("PageThickness");
     }
