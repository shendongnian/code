    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    namespace Cssd.IT.PortalIntegration.DataAccess.HR.Dao
    {
        
        /// <summary>
        /// Added interface here so that it does not get removed when updating 
        /// model from the database on code generation.
        /// </summary>
        partial class HRADDbContext : IHRADDbContext
        {
            public HRADDbContext(string nameOrConnectionString)
                : base(nameOrConnectionString)
            {
                this.Configuration.LazyLoadingEnabled = false;
            }
            public HRADDbContext(DbConnection connection)
                : base(connection, true)
            {
                this.Configuration.LazyLoadingEnabled = false;
            }
        }
    }
