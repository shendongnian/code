    public void Update<T>(T entity) where T:class
    {
            db.Entry<T>(entity).State = EntityState.Modified;
            db.SaveChanges();
    }
