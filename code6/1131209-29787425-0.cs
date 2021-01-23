     public event EventHandler SelectedChangedByUser;
     public event EventHandler SelectedChangedByCode;
     
     public object SelectedValue
     {
	   get
	   {
		     return _selectedVaue;
	   }
	   set
	   {
		if(value != _selectedValue)
		{
			_selectValue = value;
			if(NotifyPropertyChanged != null)
			{
				NotifyPropertyChanged("SelectedValue");
			}	
			
			if(SelectedChangedByUser != null)
			{
				SelectedChangedByUser(this, new EventArgs());
			}
		  }
	    }
     }
     
      public void UpdateSelectedValue(object value)
      {
	   if(value != _selectedValue)
	   {
		_selectValue = value;	
		if(SelectedChangedByCode != null)
		{
			SelectedChangedByCode(this, new EventArgs());
		}
	   }
      }
