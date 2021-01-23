    public class FooBarConfiguration : EntityTypeConfiguration<FooBar>
	{
		public FooBarConfiguration()
  		{
   			HasKey(fb => new[] { fb.FooId, fb.BarId });
            // A reversed version could be placed in the Foo configuration
            // But only one is necessary
            HasRequired(fb => fb.Foo)
                .WithMany(fb => fb.Bars)
                .HasForeignKey(fb => fb.FooId);
   			
            // Something similar for relationship with Bar
            Property(pv => pv.Active);
   
   			ToTable("ProductVehicle"); // You mean FooBar right? ;)
   		}
   	}
