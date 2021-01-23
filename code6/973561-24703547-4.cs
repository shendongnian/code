    private ColorList _selectedColor;
    public List<ColorList> AvailableColors
    {
        get
        {
            return this.GetColorsList();
        } 
    }
              
    public ColorList SelectedColor
    {
        get
        {
            return this._selectedColor;
        }
        set
        {
            if (this._selectedColor != value)
            {
                this._selectedColor = value;
                this.RaisePropertyChanged("SelectedColor");
            }
        }
    }
