    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Data.Entity.Core.EntityClient;
    
    namespace MVCTest.Models
    {
        public class EntityContext:DbContext
        {
            public EntityContext()
            : base("EmployeeEntities")
        {
            //#if DEBUG 
            Database.SetInitializer<EntityContext>(new DatabaseInitializer());
            var ensureDLLIsCopied =
                System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            //#endif
        }
            public DbSet<EmployeeModel> Employees { get; set; }
        }
    }
