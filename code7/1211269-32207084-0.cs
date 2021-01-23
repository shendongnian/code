    using (MyContextEntities db = new MyContextEntities())
    {
         db.Entry(Car).State = EntityState.Modified;
         db.Entry(model).Property(x => x.CreationDate).IsModified=false;
         db.SaveChanges();
    }
