	public void DataExport(string SelectQuery, string fileName)
	{
		using (var dt = new DataTable())
		{
			using (var da = new SqlDataAdapter(SelectQuery, con))
			{
				da.Fill(dt);
				
				var header = String.Join(
					",",
					dt.Columns.Cast<DataColumn>().Select(dc => dc.ColumnName));
						
				var rows =
					from dr in dt.Rows.Cast<DataRow>()
					select String.Join(
						",",
						from dc in dt.Columns.Cast<DataColumn>()
						let t1 = Convert.IsDBNull(dr[dc]) ? "" : dr[dc].ToString()
						let t2 = t1.Contains(",") ? String.Format("\"{0}\"", t1) : t1
						select t2);
				
				using (var sw = new StreamWriter(fileName))
				{
					sw.WriteLine(header);
					foreach (var row in rows)
					{
						sw.WriteLine(row);
					}
					sw.Close();
				}
			}
		}
	}
