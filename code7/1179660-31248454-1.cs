    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
    
        public class Location
        {
            [Key]
            public int LocationId { get; set; }
            public virtual ICollection<Tag> Tags { get; set; }
        }
    
        public class Tag
        {
            [Key]
            public int TagId { get; set; }
            public virtual ICollection<Location> Locations { get; set; }
        }
    
        public class TagLocsDbContext : DbContext
        {
            public virtual DbSet<Tag> Tags { get; set; }
            public virtual DbSet<Location> Locations { get; set; }
    
    
        }
    
        class DbInitializer : DropCreateDatabaseAlways<TagLocsDbContext>
        {
            protected override void Seed(TagLocsDbContext context)
            {
                base.Seed(context);
                context.Tags.Add(new Tag() { });
                context.Tags.Add(new Tag() { });
                context.Tags.Add(new Tag() { });
                context.Tags.Add(new Tag() { });
            }
        }
    
        public class Tests
        {
            public void Create()
            {
                using (var db = new TagLocsDbContext())
                {
                    db.Locations.Add(new Location { Tags = db.Tags.Where(p => p.TagId == 2).ToList() });
                    db.SaveChanges(); // correctly saves the new location with TagId 2 attached
                }
            }
    
            public void Edit(bool clear)
            {
                using (var db = new TagLocsDbContext())
                {
                    var location = db.Locations.Single(p => p.LocationId == 1);
                    if (clear) location.Tags.Clear();
                    location.Tags = db.Tags.Where(p => p.TagId == 1).ToList();
                    db.SaveChanges(); // if Clear ran locations = {1}, otherwise it is {1,2}
                }
            }
    
            public void EditWithConflict()
            {
                using (var db = new TagLocsDbContext())
                {
                    var location = db.Locations.Single(p => p.LocationId == 1);
                    location.Tags = db.Tags.ToList();
                    db.SaveChanges(); //Conflict - will throw an exception
                }
            }
        }
    
        class Program
        {
    
            static void Main(string[] args)
            {
                var initializer = new DbInitializer();
                Database.SetInitializer(initializer);
    
                var tests = new Tests();
                tests.Create();
                PrintLocation("After create: ", 1);
                  
                tests.Edit(false);
                PrintLocation("After edit without clear: ", 1);
    
                tests.Edit(true);
                PrintLocation("After edit with clear: ", 1);
    
                try
                {
                    tests.EditWithConflict();
                    PrintLocation("After edit with clear: ", 1);
                }
                catch (DbUpdateException exc)
                {
    
                    Console.WriteLine("Exception thrown : {0}",exc.Message);
                    PrintLocation("After edit with conflicting tags: ", 1);
                    
                }
    
                
                Console.ReadLine();
            }
    
            private static void PrintLocation(string afterCreate, int i)
            {
                Console.WriteLine(afterCreate);
                using (var db = new TagLocsDbContext())
                {
                    var location = db.Locations.Single(a => a.LocationId == i);
                    var tags = string.Join(",", location.Tags.Select(a => a.TagId));
                    Console.WriteLine("Location {0} : Tags {1}", location.LocationId, tags);
    
                }
            }
        }
    }
