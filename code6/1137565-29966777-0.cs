    public static DataTable ImportCSVtoDatatable(string filepath, string strQuery )
        {
           //var fileName = Path.GetFileName(filepath); 
    	//strQuery = @"SELECT * FROM " + fileName;
    
            DataSet ds = new DataSet();
            var constring = string.Format(@"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""", Path.GetDirectoryName(filepath));
    
            OleDbConnection con = new OleDbConnection(constring);
    
            OleDbDataAdapter da = new OleDbDataAdapter(strQuery, con);
    
          
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }
