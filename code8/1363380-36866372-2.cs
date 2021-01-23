    private System.Windows.Media.Brush _selectedColor { get; set; }
    public System.Windows.Media.Brush SelectedColorXaml
    {
        get { return _selectedColor; }
        set
        {
            _selectedColor = value;
            RaisePropertyChanged("SelectedColorXaml");
        }
    }
