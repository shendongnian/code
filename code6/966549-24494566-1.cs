    public void Update(GaDevice entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
