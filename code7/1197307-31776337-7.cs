	public class IEntityRepository : IDisposable
	{
		IQueryable<Catalog> GetVehicleByReleasedDate();
	}
	
	public class EFEntityRepository : IEntityRepository
	{
		private EntityDataModel context = new EntityDataModel():
		public IQueryable<Catalog> GetVehicleByReleasedDate()
		{
			return this.context.Catalog;
		}
		public void Dispose()
		{
			this.context.Dispose();
			this.context = null;
		}
	}
	
	public class Consumer
	{
		private Func<IEntityRepository> createRepository;
		public Consumer(Func<IEntityRepository> createRepository) { this.createRepository = createRepository; }
		public void OutputData()
		{
			using (var repository = this.createRepository())
			{
				var query = from vehicle in repository.GetVehicleByReleasedDate()
					where vehicle.ReleaseDate >= DateTime.Now
					select new
				{
					VehicleMake = vehicle.VehicleMake,
					ManufactureID = vehicle.ManufactureID,
					ManufactureDate = vehicle.ManufacturedDate,
					VehicleIdentificationNumber = vehicle.VehicleIdentificationNumber
				};
	
				foreach (var vehicle in query)
				{
					Console.WriteLine("{0} {1:d} {2} {3}",
					vehicle.ManufactureID,
					vehicle.ManufactureDate,
					vehicle.VehicleIdentificationNumber,
					vehicle.VehicleMake);
				}
	
			}
		}
	}
    public class Program
    {
        static void Main(string[] args)
        {
            var consumer = new Consumer(()=>new EFEntityRepository());
            consumer.OutputData();
        }
    }	
