    private Car _selectedCar;
    public Car SelectedCar { 
      get { return _selectedCar; } 
      set { _selectedCar = value; OnPropertyChanged("SelectedCar"); }
    }
     
    private ObservableCollection<Car> _selectedCollection = CarVM.UserCars;
    private ObservableCollection<Car> SelectedCollection { 
      get { return _selectedCollection; } 
      set { _selectedCollection = value; OnPropertyChanged("SelectedCollection"); }
    }
    private ObservableCollection<Car> _originalCollectionForReferenceKeepingOnly;
    // called via RelayCommand
    public void UserJustSelectedACar()
    {
        ObservableCollection<Car> singleItemCollection =  new ObservableCollection<Car>();
        singleItemCollection.Add(SelectedCar);
        _originalCollectionForReferenceKeepingOnly = SelectedCollection;
        SelectedCollection = singleItemCollection;
    }
    public void ReturnToFullUsedCarsList()
    {
        SelectedCollection = _originalCollectionForReferenceKeepingOnly;
    }
