    object selectedPen; 
    public object SelectedPen 
    { 
        get 
    	{ 
    		return selectedPen; 
    	} 
        set 
    	{ 
    		if (selectedPen != value)
    		{
    			selectedPen = value; 
                DoSave(); // insert saving logic here
    			OnPropertyChanged("SelectedPen"); 
    		}
    	}
    } 
