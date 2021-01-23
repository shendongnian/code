    var mappings = new Mapper[] {
		new Mapper<Student,StudentRecord>
		{
			{s=>s.Title, t=>t.EntityTitle},
			{s=>s.StudentId, t=>t.Id},
			s=>s.Name,
			s=>s.LuckyNumber,
		},
		new Mapper<Car,RaceCar>
		{
			c=>c.Color,
			c=>c.Driver,
			{c=>c.Driver.Length, r=>r.DriverNameDisplayWidth},
		},
	};
