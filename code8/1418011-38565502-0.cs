           FleetVehicle fv = new FleetVehicle()
                    {
                        BranchId = fleet.BranchId,
                        Description = fleet.Description,
                        Registration = fleet.Registration
    
                    };
         if (db.FleetVehicle.Contains(fv)
    {
    //update the item
    }
    else
    {
    //add the vehicle
    }
    db.SaveChanges()
