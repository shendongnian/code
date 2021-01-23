    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using CodeFirst.Models;
    
    namespace CodeFirstMigration.Models
    {
        public class StudentDbContext : DbContext
        {
            public StudentDbContext()
                : base("StudentDbContext")
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StudentDbContext>());
            }
            public DbSet<Student> Students { get; set; }
            public DbSet<Department> Departments { get; set; }
        }
    }
