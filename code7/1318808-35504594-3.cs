    private bool _isChecked;
    public bool IsChecked
    {
     get {return _isChecked;}
     set 
     {
       _isChecked = value;
       NotifyPropertyChanged("IsChecked");
       NotifyPropertyChanged("NumberOfSkills");
     }
    }
