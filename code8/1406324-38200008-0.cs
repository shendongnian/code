    DateTime monthParam = months.ElementAt(1);
    double? growth = forecastData.Where(x => x.Date.Month == 6)
                                    .Select(x => x.Growth).FirstOrDefault();
                
    double? sum = forecastData.Where(c => c.Date == monthParam)
                                .Sum(c =>(c.Volume * c.Growth) / growth);
