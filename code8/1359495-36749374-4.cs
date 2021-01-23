        public ObservableCollection<Employee> Employees 
        {
      	    get { return _employees; }
    	    set
    	    {
               _employees = value;
               if (PropertyChanged != null)
            	  {
                    PropertyChanged(this, new PropertyChangedEventArgs("Employees"));
                }
            }
      }
