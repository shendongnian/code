    var minPriceGroup = listCars
        .Select(c => new { Car = c, Price = decimal.Parse(c.price) })
        .OrderBy(x => x.Price)
        .GroupBy(x => x.Price)
        .First();
    lowest.AddRange(minPriceGroup.Select(x => x.Car));
