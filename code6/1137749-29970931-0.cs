	public static string GetStartOfQuery(string databaseName)
	{
	  if (VBS.Left(databaseName, 2) == "AC")
	  {
		return "Select hiredate, terminationdate, employeename, ";
	  }
	  else 
	  {
		return "Select hiredate, employeename, timeoffaccrued, timeoffused, ";
	  }
	} 
	
	public static void BuildAQuery(string databaseName)
	{
		dao.Database dd;
		dao.DBEngine db = new dao.DBEngine();
		var qd1 = new dao.QueryDef(); 
		soq = GetStartOfQuery(databaseName);
		dd = db.OpenDatabase(SetPath(databaseName));
		qd1.Name = String.Format("qry_PersonalInformation");
		qd1.SQL = String.Format(startOfQuery + "location", "empID");
		dd.QueryDefs.Append(qd1);
	}
