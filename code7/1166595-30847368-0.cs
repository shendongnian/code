    public static int getLastId<T>()
        where T : PrimaryKey
    {
        using (HatnEntities context = new HatnEntities())
        {
            // Fetch Id of last record from table
            var result = (from c in context.Set<T>().OrderByDescending(u => u.Id) select new { Id = c.Id }).FirstOrDefault();
    
            var lastID = 0;
            if (result != null)
            {
                lastID = Convert.ToInt32(result.Id);
            }
            obj.Id = lastID + 1;
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }
    
        // not sure where this comes from?
        return status;
    }
    
    public abstract class PrimaryKey
    {
        public int Id { get; set; }
    }
