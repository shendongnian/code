    private Category _selectedCategory;
    public Category SelectedCategory
    {
        get { return _selectedCategory; }
        set
        {
            _selectedCategory = value;
            OnPropertyChanged("SelectedCategory");
            OnPropertyChanged("SelectedCategoryProducts");
        }
    }
