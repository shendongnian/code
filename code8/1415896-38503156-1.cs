    public class RiskItems : OnlyRunOnSpecificDatabaseMigration
    {
        public override void Up()
        {
         
            Execute.Sql(@"update [Items] set  
                        CanBeX = 
                        case when exists(select 1 from [SomeTable] where Key = [Items].Key and position like 'Factor%') then 1 else 0 end");
        }
        public override void Down()
        {
        }
        public override List<string> DatabaseNamesToRunMigrationOnList
        {
            get
            {
                return new List<string> {"my_database_name"};
            }
        }
    }
