    [Migration(201506021451)]
    public class M116_Init_RoleManagement : ForwardOnlyMigration
    {
        public override void Up()
        {
            .
            .
            . 
            Execute.Sql(Hsk.Migrations.Properties.Resources._2015021451_CreateSalesManagerRoles);
        }
    }
