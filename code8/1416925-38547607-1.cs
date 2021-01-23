    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Stories",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Autoincrement", true),
                Author = table.Column<string>(maxLength: 64, nullable: true),
                Date = table.Column<DateTime>(nullable: false),
                Published = table.Column<bool>(nullable: false),
                Title = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Stories", x => x.Id);
            });
        migrationBuilder.CreateIndex(
            name: "IX_Stories_Date_Published",
            table: "Stories",
            columns: new[] { "Date", "Published" });
    }
