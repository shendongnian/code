    string table1 = @"\\Srverp\gab\bproved.dbf";
    string table2 = @"\\Srverp\gab\ges_01\bproalb.dbf";
    
    string con = @"Provider=VFPOLEDB;Data Source=\\Srverp\gab";
    
    string sql = string.Format(@"SELECT * FROM ('{0}') t1
    	inner join ('{1}') t2 on t1.bprovedId = t2.bprovedId",
    	table1, table2);
    
    DataTable t = new DataTable();
    using (OleDbConnection connectionHandler = new OleDbConnection(con))
    {
    	OleDbCommand cmd = new OleDbCommand(sql, connectionHandler);
    
    	connectionHandler.Open();
    	t.Load( cmd.ExecuteReader() );
    	connectionHandler.Close();
    }
    // t has yopur data
