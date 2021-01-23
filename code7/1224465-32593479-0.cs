    DataTable dt = new DataTable();
    		using (OracleConnection con = new OracleConnection(Application["ConnectionString"].ToString()))
    		{
    			con.Open();
    			string strSQL = "SELECT * FROM YourTable WHERE type = 1";
    			OracleDataAdapter adapter = new OracleDataAdapter(strSQL, con);
    			adapter.Fill(dt);
    			if (dt.Rows.Count > 0)
    				return dt.Rows[0][0].ToString();
    		}
    		return "";
