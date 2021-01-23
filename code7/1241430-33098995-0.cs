	public static void DataTable2TXT(DataTable dt, string fp)
	{
		int i = 0;
		StreamWriter sw = null;
		sw = new StreamWriter(fp, false);
		for (i = 0; i < dt.Columns.Count - 1; i++)
		{
			sw.Write(dt.Columns[i].ColumnName + ";");
		}
		sw.Write(dt.Columns[i].ColumnName);
		sw.WriteLine();
		foreach (DataRow row in dt.Rows)
		{
			object[] array = row.ItemArray;
			for (i = 0; i < array.Length - 1; i++)
			{
				sw.Write(array[i].ToString() + ";");
			}
			sw.Write(array[i].ToString());
			sw.WriteLine();
		}
		sw.Close();
	}
