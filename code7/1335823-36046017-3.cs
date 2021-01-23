    using System.Web.Http;
    ...    
    [HttpGet]
    [Route("api/Cars/GetSimpleCar")]
    public object GetCarsButOnlyIdAndColor()
    {
        return db.cars.Select(r => new
        {
            Car_ID = r.car_id,
            Color = r.Color,
        }).ToList();
    }
