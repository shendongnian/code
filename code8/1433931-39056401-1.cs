     var reservedCars = (from c in db.Cars
    
                                join o in db.Orders on c.Car_Id equals o.Car_Id
                                join u in db.AspNetUsers on o.Id equals u.Id
                                where u.Id == 5
                                select new ReservedCar
                                {
                                    Car_Id = c.Car_Id,
                                    Car_Description = c.Car_Description,
                                    Color = c.Color
                                    // Map other properties as needed.
                                }).ToList();
    return View(reserverCars);
