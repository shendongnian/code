    public void InsertVehicleWithMultipleVins(VehicleCamp vehicle, List<string> vins)
    {
        foreach(var vin in vins)
        {
            vehicle.Vin = vin;
            InsertVinCamp(vehicle);
        }
    }
