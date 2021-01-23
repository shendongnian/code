	List<Vehicle> vehicles = new List<Vehicle>();
	
	Vehicle vehicle = new Vehicle()
	{
		Id = "XPT",
		Description = "Average Car",
		Steps = new List<Step>()
		{
			new Step() {
				Name = "move car",
				Movements = new List<Movement>()
				{
					new Movement("engage 1st gear", 1, 1),
					new Movement("reach 10kph", 10, 5),
					new Movement("maintain 10kph", 10, 12),
				}
			},
			new Step() {
				Name = "stop car",
				Movements = new List<Movement>()
				{
					new Movement("reach 0kph", 10, 4),
					new Movement("put in neutral", 0, 1),
					new Movement("turn off vehicle", 0, 0),
				}
			}
		}
	};
	vehicles.Add(vehicle);
