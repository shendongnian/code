    public override void Up()
    {
        AddColumn("dbo.TableA", "NewUniqueValue", c => c.String(maxLength: 20));
        //you should add this row:
        Sql("UPDATE dbo.TableA SET NewUniqueValue = NEWID()")
        CreateIndex("dbo.TableA", "NewUniqueValue", unique: true);
    }
            
    public override void Down()
    {
        DropIndex("dbo.TableA", "NewUniqueValue");
        DropColumn("dbo.TableA", "NewUniqueValue");
    }
