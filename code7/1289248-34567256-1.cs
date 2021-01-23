    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
 
    namespace ConsoleApplication3
    {
        class Program
        {
            public static void Main()
            {
                MyContext context = new MyContext();
                context.Entities.Add(new Entity()); // CreatedOn = DateTime.Now does not compile
                context.SaveChanges();
                Console.ReadLine();
            }
        }
        public class MyContext : DbContext
        {
            public DbSet<Entity> Entities { get; set; }
            public override int SaveChanges()
            {
                ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;
                foreach (var entry in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
                {
                    var entity = entry.Entity as Entity;
                    if (entry.State == EntityState.Added)
                        entity.GetType().GetProperty("CreatedOn").SetValue(entity, DateTime.Now);
                }
                return base.SaveChanges();
            }
        }
        [Serializable]
        public class Entity
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public DateTime? CreatedOn { get; private set; }
       }
    }
