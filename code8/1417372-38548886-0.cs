    public class ImageContext : DbContext
    {
        public ImageContext (): base("DefaultConnection")
        {
        }
        public DbSet<Image> Images { get; set; }
    } 
