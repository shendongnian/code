    static void Main()
    {
    string myCode = 
    @"procedure SPTest(tcTableName)
    select * from (m.tcTableName) into cursor crsTest nofilter
    setresultset('crsTest')
    endproc";
    
    File.WriteAllText(@"d:\temp\TestSP.prg",myCode);
    
      string strCon = @"Provider=VFPOLEDB;Data Source=d:\temp";
      using(  OleDbConnection con = new OleDbConnection(strCon))
      {
        con.Open();    
        var xs = new OleDbCommand("TestSP", con);
        xs.CommandType = CommandType.StoredProcedure;
        xs.ExecuteNonQuery();
        
        var cmd = new OleDbCommand(@"update ('d:\temp\TestSP.dbc') 
          set Code = ? where ObjectName='StoredProceduresSource'", con);
        cmd.Parameters.AddWithValue("spCode", myCode);  
        cmd.ExecuteNonQuery();
        cmd = new OleDbCommand(@"update ('d:\temp\TestSP.dbc') 
          set Code = ? where ObjectName='StoredProceduresObject'", con);
        cmd.Parameters.AddWithValue("spCode", File.ReadAllBytes(@"d:\temp\TestSP.fxp"));  
        cmd.ExecuteNonQuery();
        con.Close();
       } 
       
       DataTable tbl = new DataTable();
       using(OleDbConnection con = new OleDbConnection(@"Provider=VFPOLEDB;Data Source=d:\temp\TestSP.dbc"))
       {
        var cmd = new OleDbCommand("spTest");
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("spCode", @"d:\temp\MyCustomers");  
        con.Open();
        tbl.Load(cmd.ExecuteReader());
        con.Close();
       }
       // LinqPad
       // tbl.Dump();
    }
