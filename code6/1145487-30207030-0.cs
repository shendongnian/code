    public partial class Reset: DbMigration
    {
        public override void Up()
        {
            Sql(@"
                DECLARE @result int
                SELECT @result = <query>
                IF (@result > 5)
                BEGIN
                    <migration stuff>
                END");
        }
    }
