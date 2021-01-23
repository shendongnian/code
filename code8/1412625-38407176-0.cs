    private ModelA _selectedComboBoxItem;
    public ModelA SelectedComboBoxItem
    {
        get { return _selectedComboBoxItem; }
        set 
        { 
           _selectedComboBoxItem = value; 
           Propertychanged(this, "SelectedComboBoxItem");
        }
    }
