    public string Width
	{
	    get { return _width; }
        set
		{
			_width = value;
			RaisePropertyChanged("Width")
	    }
	}
    //set our extended control to the other 30 percent of the window size
    Width = "3*";
