        private void SaveCommand_Action()
        {
            StateManager.IsBusy = true;
            Application.Current.Dispatcher.Invoke(() => Save(), System.Windows.Threading.DispatcherPriority.Background);
        }
        private void Save()
        {
            this.Validate();
            if (!HasValidationErrors)
            {
                if (this.CustomerControlVM.SaveCustomer() != 0)
                {
                    VehicleControlVM.VehicleModel.CustomerID = this.CustomerControlVM.CustomerModel.CustomerID;
                    this.VehicleControlVM.SaveVehicle();
                    ComplaintsView complaintsControl = new ComplaintsView();
                    (complaintsControl.DataContext as ComplaintsViewModel).CurrentVehicle = this.VehicleControlVM.VehicleModel;
                    (complaintsControl.DataContext as ComplaintsViewModel).CurrentCustomer = this.CustomerControlVM.CustomerModel;
                    StateManager.LoadView(complaintsControl, PageTransitionType.SlideLeft);
                    StateManager.IsBusy = false;
                }
            }
        }
