    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Data.Entity.Core.EntityClient;
    
    namespace MVCTest.Models
    {
        public class EmployeeContext : DbContext
        {
            public EmployeeContext() : base("EmployeeContext")
            {
            }
    
            public DbSet<EmployeeModel> Employees { get; set; }
        }
    }
