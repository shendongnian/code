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
                Entity.MyContext context = new Entity.MyContext();
                context.Entities.Add(new Entity());
                // context.Entities.Add(new Entity() { Created = DateTime.Now }); //Does not compile
                context.SaveChanges();
            }
       }
        [Serializable]
        public class Entity
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public DateTime? Created { get; private set; }
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
                            entity.Created = DateTime.Now;
                    }
                    return base.SaveChanges();
                }
            }
        }
    }
