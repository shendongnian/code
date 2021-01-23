    string tableName = "BlaTable";
	var genericMethodTemplate = database.GetType().GetMethod("CreateTable", new Type[0]);
    //genericMethodTemplate can be seen as database.CreateTable<T>();
	var tableType = GetTableType(tableName);
	var genericMethod = genericMethodTemplate.MakeGenericMethod(tableType);
    //now the T has been filled in with whatever table was given.
	genericMethod.Invoke(database);
