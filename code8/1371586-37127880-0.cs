    using System.Data;
    using System.Data.SqlClient;
        
    public DataTable StudentView()
           {
               SqlConnection sqlCon = new SqlConnection(@"Server= localhost\SQLINSTANCENAME; Database= DBNAME; Integrated Security=True;");
               SqlDataAdapter sqlDa = new SqlDataAdapter("QUERY", sqlCon);
               DataTable dtbl = new DataTable();
               sqlDa.Fill(dtbl);
               return dtbl;
           }
