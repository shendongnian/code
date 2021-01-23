    string sqlEq = "SELECT utk_ved FROM prod WHERE Price_N = '641857'";
    string sqlLike = "SELECT utk_ved FROM prod WHERE Price_N like '641857'";
    
    TimeSpan timeSpanODBC;
    DateTime timeODBC = DateTime.Now;
    
    OdbcConnection odbcConnection = new OdbcConnection(@"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=C:\Users\Vakshul\Documents\dbfs;Exclusive=No;Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;");
    odbcConnection.Open();
    OdbcCommand odbcCommand = new OdbcCommand(sqlEq, odbcConnection);
    odbcCommand.ExecuteScalar();
    timeSpanODBC = DateTime.Now - timeODBC;
    double timeOdbcEqual = timeSpanODBC.TotalMilliseconds;
    System.Console.WriteLine("Time spent via ODBC(milliseconds) using '=' to compare - {0}", timeOdbcEqual.ToString());
    
    
    timeODBC = DateTime.Now;
    
    odbcCommand = new OdbcCommand(sqlLike, odbcConnection);
    odbcCommand.ExecuteScalar();
    timeSpanODBC = DateTime.Now - timeODBC;
    double timeOdbcLike = timeSpanODBC.TotalMilliseconds;
    System.Console.WriteLine("Time spent via ODBC(milliseconds) using 'Like' to compare - {0}", timeOdbcLike.ToString());
    
    TimeSpan timeSpanOLEDB;
    DateTime timeOLEDB = DateTime.Now;
    
    OleDbConnection oleDbCon = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=C:\Users\Vakshul\Documents\dbfs;Collating Sequence=MACHINE;Mode=Read");
    oleDbCon.Open();
    new OleDbCommand("set enginebehavior 80", oleDbCon).ExecuteNonQuery();
    OleDbCommand oleDbcommand = new OleDbCommand(sqlEq, oleDbCon);
    oleDbcommand.ExecuteScalar();
    timeSpanOLEDB = DateTime.Now - timeOLEDB;
    double timeOLEDBEqual = timeSpanOLEDB.TotalMilliseconds;
    System.Console.WriteLine("Time spent via OLEDB(milliseconds) using '=' to compare - {0}", timeOLEDBEqual.ToString());
    
    timeOLEDB = DateTime.Now;
    
    oleDbcommand = new OleDbCommand(sqlLike, oleDbCon);
    
    oleDbcommand.ExecuteScalar();
    timeSpanOLEDB = DateTime.Now - timeOLEDB;
    double timeOLEDLike = timeSpanOLEDB.TotalMilliseconds;
    System.Console.WriteLine("Time spent via OLEDB(milliseconds) using 'Like' to compare - {0}", timeOLEDLike.ToString());
