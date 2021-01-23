    public Car SelectedCar
    {
        get
        {
            System.Diagnostics.Debug.WriteLine("[CARSVIEWMMODEL] \t" + "GET SelectedCar");
            return selectedCar;
        }
    
        set
        {
            if (value != selectedCar && value != null)
            {
                selectedCar = value;
                System.Diagnostics.Debug.WriteLine("[CARSVIEWMMODEL] \t" + "SET SelectedCar");
                RaisePropertyChanged(() => SelectedCar);
           }
        }
    }
