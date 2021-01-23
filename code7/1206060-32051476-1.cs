    public bool? AllSelected
    {
        get 
        { 
            // Check if all are checked
            if (!MyProperty.Any(x => !x.IsChecked))
            {
                return true;
            }
            // Check if none are checked
            if (!MyProperty.Any(x => x.IsChecked))
            {
                return false;
            }
            // Otherwise some are checked.
            return null;
        }
        set
        {
            _allSelected = value;
            MyProperty.ForEach(x => x.IsChecked = value);
            OnPropertyChange("AllSelected");
        }
    }
