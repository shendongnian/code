    namespace Infrastructure.Migrations
    {
        using System.Collections.Generic;
        using FluentMigrator;
        using FluentMigrator.Infrastructure;
    
        public abstract class OnlyRunOnSpecificDatabaseMigration : Migration
        {
            public abstract List<string> DatabaseNamesToRunMigrationOnList { get; }
    
            private bool DoRunMigraton(IMigrationContext context)
            {
                return this.DatabaseNamesToRunMigrationOnList == null ||
                       this.DatabaseNamesToRunMigrationOnList.Contains(new System.Data.SqlClient.SqlConnectionStringBuilder(context.Connection).InitialCatalog);
            }
    
            public override void GetUpExpressions(IMigrationContext context)
            {
                if (this.DoRunMigraton(context))
                {
                    base.GetUpExpressions(context);
                }
            }
    
            public override void GetDownExpressions(IMigrationContext context)
            {
                if (this.DoRunMigraton(context))
                {
                    base.GetDownExpressions(context);
                }
            }
        }
    }
