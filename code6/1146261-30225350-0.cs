	string sqlConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
	using (SqlConnection sqlConnection1 = new SqlConnection(sqlConn))
	{
		using (SqlCommand cmd = new SqlCommand())
		{
			cmd.CommandText = ("usp_EmployeeMarkets");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = sqlConnection1;
			cmd.Parameters.AddWithValue("EmployeeID", id);
			sqlConnection1.Open();
			SqlDataReader sdr = cmd.ExecuteReader();
			while (sdr.Read())
			{
				string value = sdr["MarketID"].ToString();
				if (value == "1")
				{
					Market1CheckBox.Checked = true;
				}
				if (value == "2")
				{
					Market2CheckBox.Checked = true;
				}
				if (value == "3")
				{
					Market3CheckBox.Checked = true;
				}
				if (value == "4")
				{
					Market4CheckBox.Checked = true;
				}
			}
		}
	}
