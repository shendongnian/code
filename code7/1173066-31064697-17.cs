    public class SchoolEntities: DbContext
    {
      public SchoolEntities()
        : base("name=SchoolEntities")
      {
      }
      public DbSet<Pupil> Pupils { get; set; }
      public DbSet<Book> Books { get; set; }
      public DbSet<SchoolclassCode> SchoolclassCodes { get; set; }
    }
