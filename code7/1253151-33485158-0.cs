    public string[] getReasons(string Accession) {
        var reasonList = new List<string>();
        SqlParameter accNumber = new SqlParameter();
        accNumber.SqlDbType = System.Data.SqlDbType.VarChar;
        accNumber.ParameterName = "@Accession";
        accNumber.Value = Accession;
        string selectText = "select reason from pendingList where accession = @Accession";
        SqlCommand selectStmt = new SqlCommand(selectText,toPending);
        selectStmt.Parameters.Add(accNumber);
    
        if (selectStmt.Connection.State == System.Data.ConnectionState.Closed) {
            selectStmt.Connection.Open();
        }
        SqlDataReader pendList = selectStmt.ExecuteReader();
    
        while (pendList.Read()) {
            reasonList.Add(pendList["reason"].toString());
        }
    
        pendList.Close();
    
        return reasonList.ToArray();
    }
