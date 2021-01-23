    private class SomeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
