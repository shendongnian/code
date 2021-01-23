    var group = d.Car.GroupBy(c=> new
                      {
                         c.Color,
                         c.Price
                       })
                     .Select(gcs=> new Cars()
                       {
                         Car =  gcs.ToList()
                       });
