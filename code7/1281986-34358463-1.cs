     private NewTruck myWnd; //View Declaration
    
    //Ctor where I set myView (myWnd) equal to a view that is passed in.
    public NewTruckViewModel(ObservableCollection<Truck> Trucks, NewTruck wnd, bool inEditTruck)
            {
                myEngine.stopHeartBeatTimer();
                editTruck = inEditTruck;
                myWnd = wnd;
                SaveTruckCommand = new SaveTruckCommand(this);
                CancelCommand = new CancelCommand(this);
                ClearCommand = new ClearCommand(this);
                SetLevel1MTCommand = new SetLevel1MTCommand(this);
                SetLevel2MTCommand = new SetLevel2MTCommand(this);
                SetLevel3MTCommand = new SetLevel3MTCommand(this);
                SetLevel1FLCommand = new SetLevel1FLCommand(this);
                SetLevel2FLCommand = new SetLevel2FLCommand(this);
                SetLevel3FLCommand = new SetLevel3FLCommand(this);
                myTrucks = Trucks;
            }
         public void Cancel()
                {
                    myWnd.Close();
                }
