    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Entity<Facility>()
                .HasMany(x => x.Ewc)
                .WithMany(x => x.Facility)
                .Map(x =>
                {
                    x.ToTable("FacilityToEwc");
                    x.MapLeftKey("FacilityId");
                    x.MapRightKey("EwcId");
                });
    
                base.OnModelCreating(modelBuilder);
            }
    
    public class Facility
    {
       public int FacilityId { get; set; }
       public string FacilityName {get; set;} 
       public ICollection<Ewc> Ewc { get; set; }
    }
    
    public class Ewc
    {
       public int EwcId { get; set; }
       public sting EwcCode { get; set;}
       public ICollection<Facility> Facility { get; set; }   
    }
