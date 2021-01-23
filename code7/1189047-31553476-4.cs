    protected override void Generate(CreateTableOperation createTableOperation) 
    {
        createTableOperation.PrimaryKey.Name = getPkName(createTableOperation.Name);
        base.Generate(createTableOperation);
	}
    protected override void Generate(AddPrimaryKeyOperation addPrimaryKeyOperation)
    {
    	addPrimaryKeyOperation.Name = getPkName(addPrimaryKeyOperation.Table);
		base.Generate(addPrimaryKeyOperation);
	}
    protected override void Generate(DropPrimaryKeyOperation dropPrimaryKeyOperation)
    {
        dropPrimaryKeyOperation.Name = getPkName(dropPrimaryKeyOperation.Table);
    	base.Generate(dropPrimaryKeyOperation);
    }
