    static IVehicle GetVehicle(VehicleType type)
    {
        IVehicle ret = null;
        switch (type)
        {
            case VehicleType.Car:
                var car = new Car() { Name = "Car Name" };
                car.Engine = "V8";
                ret = car;
                break;
            case VehicleType.Bike:
                var bike = new Bike() { Name = "Bike name" }; 
                bike.Mountainbike = true;
                ret = bike;
                break;
        }
        return ret;
    }
