     public bool IsOperationChecked // Bound to the checkbox
     {                       
         get { return _IsOperationChecked; }
         set { 
                _IsOperationChecked= value; 
                OnPropertyChanged("IsOperationChecked"); 
                Names = (value) ? new List<string>() {"alpha", "beta"} : 
                                  new List<string>() {"Bill", "Frank"};
             }
      }
    
     public List<string> Names // Bound to the Combobox
     {
        get { return _Names; }
        set { _Names = value; OnPropertyChanged("Names"); }
     }
