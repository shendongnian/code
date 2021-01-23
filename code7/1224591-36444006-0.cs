	public class PersonMap : EntityTypeConfiguration<Person>
	{
	    public Person Map()
	    {
	        Map(m => { m.ToTable("Person"); m.MapInheritedProperties(); });
	        
	        HasKey(p => p.Id);
	        Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
	    }
	    
	}
