    public class MyDbContext : DbContext
    {
        public virtual DbSet<Example> Examples { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Let EFCore ignore all models that you don't want it to be a table
            builder.Ignore<BaseModel>();
            builder.Ignore<Child1>();
            builder.Ignore<Child2>();
            builder.Entity<Example>(entity =>
            {
                entity.Property(p => p.Data).HasConversion(
                        x => JsonConvert.SerializeObject(x) //convert TO a json string
                        , x => JsonConvert.DeserializeObject<BaseModel>(x)//convert FROM a json string
                    );
            });
        }
    }
