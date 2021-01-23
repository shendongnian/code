    [HttpGet]
    [Route("api/Cars/GetSimpleCar")]
    public object GetStateLabels()
    {
        return db.cars.Select(r => new
        {
            Car_ID = r.car_id,
            Color = r.Color,
        }).ToList();
    }
