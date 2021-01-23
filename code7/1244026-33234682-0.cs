    SqlConnection cnn = new SqlConnection("cstring");
    SqlTransaction trn = null;
    cnn.Open();
    
    using (SqlCommand cmd = cnn.CreateCommand())
    {
        cmd.Connection = cnn;
    
        if(!SQLScript.Contains("FULLTEXT"))
        {
            trn = cnn.BeginTransaction();
            cmd.Transaction = trn;
        }        
            
        cmd.CommandText = SQLScript;
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
    }
    
    if(trn!=null)
        trn.Commit();
        
    cnn.Close();
