    private void loadForm()
	{
		public static DateTime FixDate(double timestamp)
			{
				DateTime origin = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
				return origin.AddSeconds(timestamp);
			}
		string query = "select * from eventTable ; ";
		OleDbConnection conn3 = new OleDbConnection(conn3str);
		OleDbDataAdapter daEvent = new OleDbDataAdapter(query, conn3);
		conn3.Open();
		DataSet dsEvent = new DataSet();
		DataTable evTable = new DataTable();
		conn3.Close();
		daEvent.FillSchema(evTable, SchemaType.Source);
		daEvent.Fill(evTable);
		evTable.Columns.Add("StartDate", typeof(DateTime));
		evTable.Columns.Add("EndDate", typeof(DateTime));
		evTable.Columns.Add("LastUpDate", typeof(DateTime));
		EnumerableRowCollection<DataRow> evRow = evTable.AsEnumerable();
		for (int i=0; i <= evTable.Rows.Count -1; i++)
		{
				double dbDt1 = Convert.ToDouble(evTable.Rows[i]["START_DATE"]);
				double dbDt2 = Convert.ToDouble(evTable.Rows[i]["END_DATE"]);
				double dbDt3 = Convert.ToDouble(evTable.Rows[i]["LAST_UPDATE"]);
				evTable.Rows[i]["StartDate"] = FixDate(dbDt1);
				evTable.Rows[i]["EndDate"] = FixDate(dbDt2);
				evTable.Rows[i]["LastUpDate"] = FixDate(dbDt3);
				DateTime dbDtDt1 = Convert.ToDateTime(evTable.Rows[i]["StartDate"]);
				DateTime dbDtDt2 = Convert.ToDateTime(evTable.Rows[i]["EndDate"]);
				DateTime dbDtDt3 = Convert.ToDateTime(evTable.Rows[i]["LastUpDate"]);
		}
		evTable.Columns.Remove("START_DATE");
		evTable.Columns.Remove("END_DATE");
		evTable.Columns.Remove("LAST_UPDATE");
		evTable.Columns["StartDate"].SetOrdinal(3);
		evTable.Columns["EndDate"].SetOrdinal(4);
		DataGridView1.DataSource = evTable;
	}
