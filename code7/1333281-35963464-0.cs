    private bool _showButton = false;
    public bool ShowButton
    {
       get { return _showButton; }
       set
       {
          if (value != _showButton)
          {
             _showButton = value;
             OnPropertyChanged("ShowButton");
          }
       }
    }
