    public abstract class EntityBase
    {
       public int Id {get; set;}
       public DateTime CreationDate {get; set;}
       public DateTime? ModifyDate {get; set;}
       public string VersionHash {get; set;}
    }
    public static class EntityBaseExtensions
    {
        public static void MyBaseEntityMapping<T>(this EntityTypeConfiguration<T> configuration) where T : EntityBase
		{
			configuration.HasKey(x => x.Id);
			configuration.Property(x => x.CreationDate)
									 .IsRequired();
			configuration.Property(x => x.ModifyDate)
									 .IsOptional();
			configuration.Property(x => x.VersionHash).IsConcurrencyToken();
		} 
    }
    public class MyEntity : EntityBase
    {
       public string MyProperty {get; set;}
    }
    public class MyEntityMapping : EntityTypeConfiguration<MyEntity>
    {
        public MyEntityMapping()
        {
           this.MyBaseEntityMapping();
           Property(x=>x.MyProperty).IsRequired();
        }
    }
    public class MyContext : DbContext
    {
        ....
        public override int SaveChanges()
		{
			this.ChangeTracker.DetectChanges(); //this forces EF to compare changes to originals including references and one to many relationships, I'm in the habit of doing this.
			var context = ((IObjectContextAdapter)this).ObjectContext; //grab the underlying context
			var ostateEntries = context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added); // grab the entity entries (add/remove, queried) in the current context
			
			var stateEntries = ostateEntries.Where(x => x.IsRelationship == false && x.Entity is EntityBase); // don't care about relationships, but has to inherit from EntityBase
			var time = DateTime.Now; //getting a date for our auditing dates
			foreach (var entry in stateEntries)
			{
				var entity = entry.Entity as EntityBase;
				if (entity != null) //redundant, but resharper still yells at you :)
				{
					if (entry.State == EntityState.Added) //could also look at Id field > 0, but this is safe enough
					{
						entity.CreationDate = time;
					}
					entity.ModifyDate = time;
					entity.VersionHash = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10); //this an example of a simple random configuration of letters/numbers..  since the query on sql server is primarily using the primary key index, you can use whatever you want without worrying about query execution.. just don't query on the version itself!
				}
			}
			return base.SaveChanges();
		}
        ....
    }
