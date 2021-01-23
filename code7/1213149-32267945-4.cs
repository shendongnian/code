	public override void Up()
	{
		CreateTable(
			"dbo.QuestionModel",
			c => new
			{
				ID = c.Guid(nullable: false, identity: true),
				Question = c.String(nullable: false, maxLength: 250),
			})
			.PrimaryKey(t => t.ID);
		CreateTable(
			"dbo.QuestionTypeModel",
			c => new
			{
				ID = c.Guid(nullable: false, identity: true),
				TypeName = c.String(nullable: false, maxLength: 250),
			})
			.PrimaryKey(t => t.ID);
		CreateTable(
			"dbo.QuestionQuestionTypesModel",
			c => new
				{
					QuestionID = c.Guid(nullable: false),
					QuestionTypeID = c.Guid(nullable: false),
				})
			.PrimaryKey(t => new { t.QuestionID, t.QuestionTypeID })
			.ForeignKey("dbo.QuestionModel", t => t.QuestionID, cascadeDelete: true)
			.ForeignKey("dbo.QuestionTypeModel", t => t.QuestionTypeID, cascadeDelete: true)
			.Index(t => t.QuestionID)
			.Index(t => t.QuestionTypeID);
	}
