                migrationBuilder.CreateTable(
                name: "InvoiceConsumers",
                columns: table => new
                {
                   …,
                    InvoiceId = table.Column<int>(nullable: false),
                    InvoiceId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceConsumers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceConsumers_Consumers_ConsumerId",
                        …);
                    table.ForeignKey(
                        name: "FK_InvoiceConsumers_Invoices_InvoiceId",
                        …
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        …
                        column: x => x.InvoiceId1,
                        principalTable: "Invoices",
                        …
                        );
                });
       
