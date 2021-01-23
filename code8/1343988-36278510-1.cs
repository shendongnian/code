    private bool _showButton = false;
    public bool ShowButton
    {
       get { 
             //you can write logic here to get values from XML
             return _showButton; 
       }
       set
       {
          if (value != _showButton)
          {
             //you can write logic here to get values from XML
             _showButton = value;
             OnPropertyChanged("ShowButton");
          }
       }
    }
