    public void SaveChanges(List<Product> added, List<Product> edited, List<Product> deleted)
    {
        using (var db = new SampleDbContext())
        {
            foreach (var entity in deleted)
            {
                if (edited.Contains(entity))
                    edited.Remove(entity);
                if (added.Contains(entity))
                    added.Remove(entity);
                else
                    db.Entry(entity).State = EntityState.Deleted;
            }
            foreach (var entity in added)
            {
                if (edited.Contains(entity))
                    edited.Remove(entity);
                db.Entry(entity).State = EntityState.Added;
            }
            foreach (var entity in edited)
                db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
