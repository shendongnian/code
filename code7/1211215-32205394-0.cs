     using (MyContextEntities db = new MyContextEntities())
     {
            db.Cars.Add(car);
            db.SaveChanges();
     }
     return car.Id
   
