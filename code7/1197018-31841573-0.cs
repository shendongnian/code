    private Car _selectedCar;
    public Car SelectedCar { 
      get { return _selectedCar; } 
      set { _selectedCar = value; OnPropertyChanged("SelectedCar"); }
    }
     
    private ObservableCollection<Car> _selectedCollection = CarVM.UserCars;
    private ObservableCollection<Car> SelectedCollection { 
      get { return _selectedCollection; } 
      set { _selectedCollection = value;OnPropertyChanged("SelectedCollection"); }
    }
    // called via RelayCommand
    public void UserJustSelectedACar()
    {
        ObservableCollection<Car> singleItemCollection =  new ObservableCollection<Car>();
        singleItemCollection.Add(SelectedCar);
        SelectedCollection = singleItemCollection;
    }
    public void ReturnToFullUsedCarsList()
    {
        SelectedCollection = CarVM.UserCars;
    }
