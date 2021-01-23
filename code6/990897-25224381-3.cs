    StateManager.IsBusyProcess(() =>
            {
                this.Validate();
                if (!HasValidationErrors)
                {
                    if (this.CustomerControlVM.SaveCustomer() != 0)
                    {
                        VehicleControlVM.VehicleModel.CustomerID = this.CustomerControlVM.CustomerModel.CustomerID;
                        this.VehicleControlVM.SaveVehicle();
                    }
                }
            });
            ComplaintsView complaintsControl = new ComplaintsView();
            (complaintsControl.DataContext as ComplaintsViewModel).CurrentVehicle = this.VehicleControlVM.VehicleModel;
            (complaintsControl.DataContext as ComplaintsViewModel).CurrentCustomer = this.CustomerControlVM.CustomerModel;
            StateManager.LoadView(complaintsControl, PageTransitionType.SlideLeft);
