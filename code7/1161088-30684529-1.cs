    public Int32 SelectedVehicleNumber
    {
        get { return PrimaryModel.Vehicle.Number; }
        set
        {
            if (PrimaryModel.Vehicle.Number != value)
            {
                PrimaryModel.Vehicle = New Vehicle(value);//Create instance by selected value
                RaisePropertyChanged("SelectedVehicle");
            }
        }
    }
