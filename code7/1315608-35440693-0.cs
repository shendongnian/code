    public class GSDbContext : IdentityDbContext<ApplicationUser>
    {
        // put your OTHER entities apart from identity related onces
        public IDbSet<MyModel> MyModels { get; set; }
        // and so on
    }
