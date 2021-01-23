	static void Main(string[] args)
	{
		var serverConnection = new ServerConnection(serverInstance: ".");
		var server = new Server(new ServerConnection());
		var scripter = new Scripter(server) { Options = { ScriptData = true } };
		serverConnection.BeginTransaction();
		ScriptData(".", server.Databases["NORTHWND"], scripter);
		serverConnection.RollBackTransaction();
	}
	public static void ScriptData(string filePath, Database db, Scripter scripter)
	{
		scripter.Options.ScriptData = true;
		scripter.Options.ScriptSchema = false;
		scripter.Options.WithDependencies = false;
		scripter.Options.IncludeHeaders = false;
		foreach (Table tbl in db.Tables.Cast<Table>().Where(t => !t.IsSystemObject))
		{
			scripter.Options.FileName = filePath + @"\MySqlInsertDataStatements.sql";
			tbl.EnumScript(scripter.Options);
		}
	}
