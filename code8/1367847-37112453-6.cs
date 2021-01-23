    public static string ScriptDatabase( string dbConnectionString, string databaseName )
	{
		SqlConnection conn = new SqlConnection( dbConnectionString );
		ServerConnection serverConn = new ServerConnection( conn );
		var server = new Server( serverConn );
		var database = server.Databases[ databaseName ];
		var scripter = new Scripter( server );
		scripter.Options.IncludeIfNotExists = true;
		scripter.Options.ScriptSchema = true;
		scripter.Options.ScriptData = true;
					
		string scrs = "";
		foreach( Table myTable in database.Tables )
		{
			foreach( string s in scripter.EnumScript( new Urn[] { myTable.Urn } ) )
				scrs += s + "\n\n"; ;
		}
		return ( scrs );
	}
