    public void GetInfo(Route route, Pickup pickup, int vehicleId)
    {
        Console.WriteLine(route.Id);
        Console.WriteLine(route.Date);
        Console.WriteLine(route.Schedule);
        var vehicle = route.Vehicles.Where(v => v.vehicleId == vehicleId).FirstOrDefault();
        if (vehicle != null)
        {
            Console.WriteLine(vehicle.VehicleRego);
        }
        Console.WriteLine(pickup.Supplier.Id);
    }
