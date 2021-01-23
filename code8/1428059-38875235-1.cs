    AddColumn("dbo.Employees", "Date", c => c.DateTime(nullable: true));
	..
	..
	.. 
	Sql("Update....")
	..
	..
	AlterColumn("dbo.Employees", "Date", c => c.DateTime(nullable: false));
		   
