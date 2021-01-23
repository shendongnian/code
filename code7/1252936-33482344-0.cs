    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WebSiteName.Models;
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    namespace WebSiteName.Migrations
    {
        internal sealed class Configuration : DbMigrationsConfiguration<WebSiteName.Models.ApplicationDbContext>
        {
            public Configuration()
            {
                AutomaticMigrationsEnabled = false;
            }
    
            protected override void Seed(WebSiteName.Models.ApplicationDbContext context)
            {
                //  This method will be called after migrating to the latest version.
    
                // Linq Method
                /*
                 * var passwordHash = new PasswordHasher();
                 * string password = passwordHash.HashPassword("Password@123");
                 * context.Users.AddOrUpdate(u => u.UserName,
                 *   new ApplicationUser
                 *   {
                 *       UserName = "Steve@Steve.com",
                 *       PasswordHash=password,
                 *       PhoneNumber = "08869879"
                 * 
                 *   });
                 */
            }
        }
    }
