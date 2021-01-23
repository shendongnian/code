    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MasterRentalModel masterRentalModel = new MasterRentalModel();
            // Fill the list of RentalType here
            masterRentalModel.MasterRentalTypeColl.Add(new MasterRentalType() { RentalTypeId = "1", RentalTypeName = "Monthly" });
            masterRentalModel.MasterRentalTypeColl.Add(new MasterRentalType() { RentalTypeId = "2", RentalTypeName = "Quarterly" });
            masterRentalModel.MasterRentalTypeColl.Add(new MasterRentalType() { RentalTypeId = "1", RentalTypeName = "Yearly" });
            cb_rentaltype.DataContext = masterRentalModel;
        }
