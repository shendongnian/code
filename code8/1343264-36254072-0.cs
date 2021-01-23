    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RecreationalServicesTicketingSystem.Models; // this is the namespace that has the new context
    using System.Collections.Generic;
    
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext> //References the new one now
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    
        protected override void Seed(ApplicationDbContext context)//References the new one now
        {...}
        //...other code removed for prebity
    }
