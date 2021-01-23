	public sealed class DependentMap : EntityTypeConfiguration<Dependent>
	{
		internal DependentMap()
		{
			Map(configuration => configuration.MapInheritedProperties());
			this.ToTable("DependentAnimals").HasKey(t => t.DependentId); // making up some table name and pk here
			
			// mapping types
			// you could probably also map this using reflection if you structure your concrete types to include some type of indicator
			Map<DogDependent>(configuration => configuration.Requires("AnimalType").HasValue("Dog");
			Map<TigerDependent>(configuration => configuration.Requires("AnimalType").HasValue("Tiger");
		}
	}
