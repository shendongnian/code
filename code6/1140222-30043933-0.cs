	var services = new List<Service>()
	{
		new Service()
		{
			Name = "A",
			ChildServices = new List<Service>()
			{
				new Service() { Name = "C", ChildServices = new List<Service>() },
				new Service()
				{
					Name = "D",
					ChildServices = new List<Service>()
					{
						new Service() { Name = "E", ChildServices = new List<Service>() },
						new Service() { Name = "F", ChildServices = new List<Service>() },
					}
				},
			}
		},
		new Service()
		{
			Name = "B",
			ChildServices = new List<Service>()
			{
				new Service() { Name = "G", ChildServices = new List<Service>() },
				new Service() { Name = "H", ChildServices = new List<Service>() },
			}
		},
	};
