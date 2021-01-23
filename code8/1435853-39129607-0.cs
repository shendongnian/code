    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            table: "Blogs",
            name: "Id",
            nullable: false)
            // Use AUTOINCREMENT on SQLite
            .Annotation("Autoincrement", true)
            // Use IDENTITY on SQL Server
            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        if (ActiveProvider == "Microsoft.EntityFrameworkCore.SqlServer")
        {
            migrationBuilder.CreateSequence("SomeSequence");
        }
    }
