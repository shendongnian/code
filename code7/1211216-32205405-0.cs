    using (MyContextEntities db = new MyContextEntities())
    {
         db.Entry(car).State = EntityState.Added;
         db.SaveChanges();
         return car.Id;
    }
