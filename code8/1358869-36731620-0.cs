    private DetailViewModel _detailVM;
    
    public MainViewModel SelectedItem
    {
      get { return _selectedItem; }
      set
      {
        _selectedItem = value;
        _detailVM = new DetailViewModel.Parameter {
            Date = Date,
            Age = _selectedItem.Age,
            Category = _selectedItem.Category,
            Discount = _selectedItem.Discount
        };
    
        ShowViewModel<DetailViewModel>(_detailVM);
    
        RaisePropertyChanged(() => SelectedItem);
      }
    }
