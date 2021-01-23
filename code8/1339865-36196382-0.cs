	using (con)
	 {
	   cmd.CommandType = CommandType.StoredProcedure;
	   cmd.CommandText = "prc_GetData";
	   cmd.Parameters.Add(new OracleParameter("piCompany", OracleDbType.Char, "01", ParameterDirection.Input));
	   cmd.Parameters.Add(new OracleParameter("poRecordset", OracleDbType.RefCursor, ParameterDirection.Output));
	   cmd.Connection = con;
	 
	   OracleDataAdapter da = new OracleDataAdapter();
	   DataTable dt = new DataTable();
	 
	   con.Open();
	   da.SelectCommand = cmd;
	   da.Fill(dt);
	 
	   dt.Columns.Add("FORMAT_COL", typeof(String));
	 
	   string space = "&nbsp;";
	   space = Server.HtmlDecode(space);
	 
	   foreach (DataRow dr in dt.Rows)
	   {
	       dr["FORMAT_COL"] = dr["NumberCol"].ToString().PadLeft(5, Convert.ToChar(space));
	   }
	   dt.Columns.Add("COMB_COL", typeof(String));
	   dt.Columns["COMB_COL"].Expression = "FORMAT_COL + '  (' + TextCol + ')'";
	 
	   ListBox1.DataSource = dt;
	   ListBox1.DataValueField = "NumberCol";
	   ListBox1.DataTextField = "COMB_COL";
	 
	   ListBox1.DataBind();
	 }
