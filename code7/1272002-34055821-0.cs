    public interface IDataContext : IDisposable
    {
        void SaveChanges();
        IQueryable<Item> GetItems();
    }
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(string connectionStringName) : base(connectionStringName) { }
        public DbSet<Item> Items { get; set; }
        
        public IQueryable<Item> GetItems()
        {
            return Items.Where(item => item.Archived == null).OrderBy(item  => item.Alias); 
        }
    }
    using (IDataContext context = new DataContext("myConnection"))
    {
        var items = context.GetItems();
    }
