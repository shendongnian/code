    // YourStaticClass.cs
	public static IEnumerable<Catalog> GetVehicleByReleasedDate(DateTime parameter)
	{
		using (var context = new EntityDataModel())
		{
			return context.Catalog
				.Where(x => parameter.Date <= x.ReleaseDate)
				.ToList();
		}
	}
	// Main.cs
	static void Main(string[] args)
	{
		var vehicles = YourStaticClass.GetVehicleByReleasedDate(DateTime.Today);
		foreach (var vehicle in vehicles)
		{
			Console.WriteLine("{0} {1:d} {2} {3}",
			vehicle.ManufactureID,
			vehicle.ManufactureDate,
			vehicle.VehicleIdentificationNumber,
			vehicle.VehicleMake);
		}
		Console.ReadKey();
	}
