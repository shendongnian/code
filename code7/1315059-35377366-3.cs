    public bool IsSelected
    {
        get { return isSelected; }
        set 
        { 
            isSelected = value;
            RaiseChange("IsSelected");
        }
    }
