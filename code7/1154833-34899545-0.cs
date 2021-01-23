    public abstract class MigrationBase : FluentMigrator.Migration
    {
        public override void Down()
        {
            //Do what you want for every migration
        }
    }
    [FluentMigrator.Migration(209912312359)]
    public class M209912312359 : MigrationBase
    {
        public override void Up()
        {
            //New migration...
        }
    }
