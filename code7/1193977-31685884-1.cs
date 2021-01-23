    public void Update(T1 obj)
    {
        T2 item = Mapper.Map<T1, T2>(obj);
        db.Set<T2>().Attach(item);
        db.Entry<T2>(item).State = EntityState.Modified;
        db.SaveChanges();
    }
