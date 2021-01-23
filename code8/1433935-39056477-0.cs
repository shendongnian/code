    var reservedCars = (from c in db.Cars
    
                                join o in db.Orders on c.Car_Id equals o.Car_Id
                                join u in db.AspNetUsers on o.Id equals u.Id
                                where u.Id == 5
                                select new
                                {
                                    c.Car_Description,
                                    c.Car_Id,
                                    c.CarMakeId,
                                    c.CarModelId,
                                    c.Reservation_Status,
                                    c.Color
                                }).ToList();
      db.Dispose();
