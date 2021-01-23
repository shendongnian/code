	public class Company
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Modem> Modems { get; set; }
	}
	public class Modem
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public virtual Company Company { get; set; }
	}
	public class MyDbContext : DbContext
	{
		public DbSet<Company> Companies { get; set; }
		public DbSet<Modem> Modems { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Company>()
                .HasMany(company => company.Modems)
                .WithOptional(modem => modem.Company)
                .Map(action => action.MapKey("Company_ID"));
			base.OnModelCreating(modelBuilder);
		}
    }
