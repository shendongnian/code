    public Abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
 
    public class CoreContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
      
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Configurations.Add(new PersonMap());
             modelBuilder.Configurations.Add(new StudentMap());
             modelBuilder.Configurations.Add(new TeacherMap());
        }
    }
 
    var testStudents = context.Person.OfType<Students>().ToList();
     var testTeachers = context.Person.OfType<Teacher>().ToList();
