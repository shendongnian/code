    public interface IEntity
    {
        int Id { get; set; }
    }
    
    public static int GetMaxId<TEntity>() where TEntity : IEntity
    {
        return MyDbContext.Set<TEntity>().AsEnumerable().Max(e => e.Id);
    }
    
    public Entity : IEntity
    {
        public int MyId { get; set;}
    
        public int Id { get{ return MyId; } set{ MyId = value; } }
    }
