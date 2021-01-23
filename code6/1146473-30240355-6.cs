     private Models.Account _selectedAccount = null;
     public object SelectedAccount
     {
        get { return _selectedAccount; }
        set
        {
            if (_selectedAccount != value)
            {
               _selectedAccount = (Models.Account)value;
               RaisePropertyChanged();
               RaisePropertyChanged("Folders");
            }
         }
      }
