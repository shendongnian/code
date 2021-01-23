    private bool _checkBoxIsChecked;
    
    public bool CheckBoxIsChecked
    {
       get{ return _checkBoxIsChecked;}
       set{_checkBoxIsChecked = value; OnPropertyChanged("CheckBoxIsChecked"); }
    }
