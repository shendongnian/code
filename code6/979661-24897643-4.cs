    using (var cn = new SqlConnection("connection string"))
    {
    	cn.Open();
    	using (var cmd = cn.CreateCommand())
    	{
            // set the command text
    const string sqlQuery = "SELECT ID " +
                            "FROM CleaningCycleTime " +
                            "WHERE ActualFinishDayTime < DATEADD(day, -60, GETDATE()) AND LotWorkOrder = '@LotWorkOrder' AND Process = '@Process' AND CleanType = '@CleanType' " +
                            "Group By ID " +
                            "Having (Min(ActualStartDayTime) IS NOT NULL AND Max(ActualFinishDayTime) IS NOT NULL)";
            cmd.CommandText = sqlQuery;
            // Add your paramters to the command object.
            cmd.Parameters.AddWithValue("@LotWorkOrder", lstOpenCleans.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Process", lstProcess.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@CleanType", lstProcess.SelectedItem.ToString());
    
    		using (var reader = cmd.ExecuteReader())
    		{
    
    			while (reader.Read())
    			{
    				txtID.Text = myReader["ID"].ToString();
    			}
    		}
    	}
    }
