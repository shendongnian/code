    [Route("api/v1/[controller]")]
    public class CarController : Controller
    {
        private readonly VehicleFactory factory;
        public CarController(VehicleFactory factory)
        {
            this.factory = factory;
        }
        [HttpGet("{vehicleType}")]
        public IEnumerable<Vehicle> GetVehicles(string vehicleType)
        {
            var repository = factory.Create(vehicleType);
            var vehicles = repository.GetAll();
            foreach (var vehicle in vehicles)
            {
                // Process(vehicle)
            }
            return vehicles;
        }
    }
