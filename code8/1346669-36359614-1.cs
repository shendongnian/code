    public class OdeToFoodDB : DbContext
    {
        public OdeToFoodDb : base("name=DefaultConnection")
        {
    
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
