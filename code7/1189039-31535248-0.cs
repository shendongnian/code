    string _selectedCell;
    public string SelectedCell
    {
       get { return _selectedCell; }
       set
       {
          _selectedCell= value;
          RaisepropertyChanged("SelectedCell");
          // Your functionality for "cell value changed" goes here
       }
    }
