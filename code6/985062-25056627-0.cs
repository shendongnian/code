    using(CarEntities db = new CarEntities())
    {
        if(!db.vehicles.Any(v => v.Name == "carName"))
        {
           // add new car to db
        }
    }
