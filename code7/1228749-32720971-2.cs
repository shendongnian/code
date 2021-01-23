	public string SelectedControl
	{
	    get {  return _selectedControl;}
        set
        {
            if (_selectedControl != value)
            {
                Set(() => Contrast, ref _selectedControl, value);
				if(_selectedControl.Equals("brightness"))
					this.Value = this.Brightness;
				else if(_selectedControl.Equals("contrast"))
					this.Value = this.Contrast;
            }
        }
	}
