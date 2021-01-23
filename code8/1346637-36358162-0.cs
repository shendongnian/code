	public DataTable Get_List_of_ManualSchemes()
		{
			DataTable comboSource = new DataTable();
			comboSource.Columns.Add("value", typeof(Int32));
			comboSource.Columns.Add("text");
			DataRow newRow;
			using (SqlConnection cnn = new SqlConnection(connectionString))
			{
				cnn.Open();
				string query = "SELECT [idGMRScheme],[SchemeName] FROM [DBA_Admin].[dbo].[GMR_Schemes]";
				using (SqlCommand command = new SqlCommand(query, cnn))
				using (SqlDataReader reader = command.ExecuteReader())
					while (reader.Read())
					{
						newRow = comboSource.NewRow();
						newRow["value"] = (Int32)reader["idGMRScheme"];
						newRow["text"] = reader["SchemeName"].ToString();
						comboSource.Rows.Add(newRow);
					}
			}
			return comboSource;
		}
		public void Populate_ManualSchemes_Combolist(DataTable comboSource)
		{
			cb_SchemesManual.DataSource = comboSource;
			cb_SchemesManual.ValueMember = "value";
			cb_SchemesManual.DisplayMember = "text";
		}
