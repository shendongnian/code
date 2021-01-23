    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      modelBuilder.Conventions.Add<MyPluralizingTableNameConvention>();
      base.OnModelCreating(modelBuilder);
    }
    public class MyPluralizingTableNameConvention : PluralizingTableNameConvention
    {
      public override void Apply(EntityType item, DbModel model)
      {
        // Do your work here
        base.Apply(item, model);
      }
    }
