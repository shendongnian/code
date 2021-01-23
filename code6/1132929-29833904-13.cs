    public bool ToggleIsSelected
    {
        get
        {
            return IsSelected ?? false;
        }
        set
        {
            if (value == IsSelected)
                return;
            IsSelected = value;
        }
    }
