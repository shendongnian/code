    abstract internal class Vehicle
    {
        public virtual Action<Vehicle> VehicleManipulator { get; set; }
        public void ManipulateVehicle()
        {
            this.VehicleManipulator(this);
        }
    }
    internal class Car : Vehicle
    {
    }
