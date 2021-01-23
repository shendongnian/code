    public interface IDbContext : IDisposable
    {
        IDbSet<Employee> Employees { get; set; }
        IDbSet<Equipment> Furniture { get; set; }
    }
    
    public class RepositoryContext : DbContext, IDbContext
    {
        public RepositoryContext() : base("name=RepositoryContext")
        {
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Equipment> Furniture { get; set; }
    }
