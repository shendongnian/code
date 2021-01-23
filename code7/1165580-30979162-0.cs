    private void XtraReport1_BeforePrint(object sender, PrintEventArgs e)
    {
        var vehicleTypes = new DataTable("VehicleTypes");
        vehicleTypes.Columns.Add("Type", typeof(string));
        vehicleTypes.Rows.Add("Cars");
        vehicleTypes.Rows.Add("Bikes");
        var vehicles = new DataTable("Vehicles");
        vehicles.Columns.Add("Type", typeof(string));
        vehicles.Columns.Add("Name", typeof(string));
        vehicles.Rows.Add("Cars", "BMW");
        vehicles.Rows.Add("Cars", "Datsun");
        vehicles.Rows.Add("Cars", "Hyundai");
        vehicles.Rows.Add("Bikes", "Honda");
        vehicles.Rows.Add("Bikes", "Moto");
        vehicles.Rows.Add("Bikes", "Yamaha");
        var dataSet = new DataSet("Data");
        dataSet.Tables.Add(vehicleTypes);
        dataSet.Tables.Add(vehicles);
        dataSet.Relations.Add("VehiclesRelation", vehicleTypes.Columns["Type"], vehicles.Columns["Type"]);
        DataSource = dataSet;
        vehicleTypeLabel.DataBindings.Add("Text", dataSet, "Type");
        VehicleDetailReport.DataMember = "VehiclesRelation";
        vehicleLabel.DataBindings.Add("Text", dataSet, "VehiclesRelation.Name");
    }
