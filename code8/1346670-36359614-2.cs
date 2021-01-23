    public class OdeToFoodDB : DbContext
    {
        public OdeToFoodDB : base("name=DefaultConnection")
        {
    
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
