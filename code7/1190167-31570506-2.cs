	private object[] GetSumRow(DataTable table, string nameToMatchAgainst, int nameColumnIndex = 0)
	{
		object[] sumRow = new object[table.Columns.Count];
		IEnumerable<DataRow> rows = table.Rows.Cast<DataRow>().Where(r => r[nameColumnIndex].ToString() == nameToMatchAgainst);
		for (int i = 0; i < table.Columns.Count; i++)
		{
			if (i == nameColumnIndex)
			{
				sumRow[i] = nameToMatchAgainst;
			}
			else
			{
				sumRow[i] = rows.Sum(r => int.Parse(r[i].ToString()));
			}
		}
		return sumRow;
	}
