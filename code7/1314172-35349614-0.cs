    var info = dbContext.Vehicles
        .Where(v => v.Id == 1234)
        .Select(v => new
        {
            VehicleName = v.Name,
            LowestPrice = v.VehicleType.Prices.Min(p => (int?)p.Price)
        })
        .SingleOrDefault();
