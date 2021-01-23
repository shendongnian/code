    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    
    namespace UsersCodeFirst
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var db = new EfContext())
                {
                    // Display all users with their education from the database 
                    var query = from user in db.Users 
                               join userEducation in db.UserEducations
                               on user.UserId equals userEducation.UserId
                        orderby user.Name
                        select new
                        {
                            Name = user.Name,
                            UserEducation = userEducation.CourseName
                        };
    
                    //bind to grid by setting grid data source to query.ToList()
                }
    
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    
        public class User
        {
            public string UserId { get; set; }
            public string Name { get; set; }
            public virtual List<Education> Posts { get; set; }
        }
    
        public class Education
        {
            public string EducationId { get; set; }
            public string CourseName { get; set; }
            public string UserId { get; set; }
        }
    
        public class EfContext : DbContext
        {
            public DbSet<Education> UserEducations { get; set; }
            public DbSet<User> Users { get; set; }
        }
    }
