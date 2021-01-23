    private void button1_Click(object sender, EventArgs e)
    {
        dbConnection conObj = new dbConnection();
        OracleConnection theConn = conObj.connFunc();
    
        String p_m_id, p_movie_name, p_year, p_category;
        p_m_id = movie_id.Text;
        p_movie_name = movie_name.Text;
        p_year = year.Text;
        p_category = category.Text;
    	
    	theConn.Open();
    	
    	OracleCommand cmd = theConn.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
    	cmd.CommandText = "insertMovie";
    	cmd.Connection = theConn;
    
        OracleParameter parChoiceIn = new OracleParameter();
        OracleParameter parDataIn = new OracleParameter();
    
        parChoiceIn.ParameterName = "p_m_id";
        parChoiceIn.OracleType = OracleType.Number;
        parChoiceIn.Size = 32;
        parChoiceIn.Direction = System.Data.ParameterDirection.Input;
        parChoiceIn.Value = p_m_id;
    	cmd.Parameters.Add(parChoiceIn);
    
        parDataIn.ParameterName = "p_movie_name";
        parDataIn.OracleType = OracleType.VarChar;
        parDataIn.Size = 32;
        parDataIn.Direction = System.Data.ParameterDirection.Input;
        parDataIn.Value = p_movie_name;
    	cmd.Parameters.Add(parDataIn);
    
    	parDataIn = new OracleParameter();
        parDataIn.ParameterName = "p_year";
        parDataIn.OracleType = OracleType.Number;
        parDataIn.Size = 32;
        parDataIn.Direction = System.Data.ParameterDirection.Input;
        parDataIn.Value = p_year;
    	cmd.Parameters.Add(parDataIn);
    
    	parDataIn = new OracleParameter();
        parDataIn.ParameterName = "p_category";
        parDataIn.OracleType = OracleType.VarChar;
        parDataIn.Size = 32;
        parDataIn.Direction = System.Data.ParameterDirection.Input;
        parDataIn.Value = p_category;
    	cmd.Parameters.Add(parDataIn);
    	
    	cmd.ExecuteNonQuery();
    
        theConn.Close();
    }
