        var table = new DataTable();
        table.Columns.Add("ParameterCode", typeof(string)).MaxLength = 64;
        table.Columns.Add("Value", typeof(string)).MaxLength = 64;
        foreach (var criterion in request.Criteria)
        {
			var newRow = table.NewRow();
			newRow[0] = criterion.Key;
			newRow[1] = criterion.Value;
			table.Rows.Add(newRow);
        }
		using (var connection = new SqlConnection("connectionString"))
		using (var command = new SqlCommand("dbo.ComputeBasedOnCriteria", connection))
		{
			var tvp = command.Parameters.Add("@CriteriaTable", SqlDbType.Structured);
			tvp.TypeName = "dbo.CriteriaTableType";
			tvp.Value = table;
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					//Do Something with your results
				}
			}
		}
