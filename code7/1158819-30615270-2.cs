    static IVehicle GetVehicle(VehicleType type)
    {
        switch (type)
        {
            case VehicleType.Car:
                return new Car() { Engine = "V8", Name = "Car Name" };
            case VehicleType.Bike:
                return new Bike() { Mountainbike = true, Name = "Bike name" }; 
        }
        return null;
    }
