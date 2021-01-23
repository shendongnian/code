    var dto = wrapper.Cars.Car.Select(c => new CarsDto
    {
        Name = c.Name,
        Country = c.Country,
        Engines = (c.Engines ?? new Engines()).Engine.Select(e => e.Name).ToList(),
    }).ToList();
