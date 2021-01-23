    public interface IVehicleRepository
    {
        bool CanHandle(string vendor); // example how to deal with choosing appropriate repository
        IEnumerable<Vehicle> GetAll();
    }
    public class VehicleFactory
    {
        private readonly IVehicleRepository[] repositories;
        public VehicleFactory(IVehicleRepository[] repositories)
        {
            this.repositories = repositories;
        }
        public IVehicleRepository Create(string vendor) {
            return repositories.Single(r => r.CanHandle(vendor));
        }
    }
