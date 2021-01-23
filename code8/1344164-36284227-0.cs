	private DataSet GetNameData()
	{
			string sql = "select Firstname, Lastname from Names where Firstname like '@Letter%';";
			
			SqlParameter arg = new SqlParamter("@Letter", ddlLetter.SelectedItem.Value));
			
			SqlCommand cmd = new SqlCommand, sql, ConnectionString);
			cmd.Paramters.Add(arg);
			
			SqlDataAdapter da = new SqlDataAdapter();
			DataSet ds = new DataSet();
			
			da.SelectCommand = cmd;
			da.Fill(ds);
			
			return ds;
	}
	private void ddlLetter_SelectedIndexChanged(object sender, EventArgs e)
	{
		DataSet Names = GetNameData();
		
		ddlNames.DataSource = Names.Table[0];
		ddlNames.DataTextField = "Firstname";
		ddlNames.DataValueField = "Id";
		ddlNames.DataBind();
		ddlNames.Items.Insert(0, new ListItem("Please select a name", 0);
	}
