    private System.Windows.Media.Brush _selectedColor 
    public System.Windows.Media.Brush selectedColorXaml
    {
        get { return _selectedColor; }
        set
        {
            _selectedColor = value;
            RaisePropertyChanged("selectedColorXaml");
        }
    }
