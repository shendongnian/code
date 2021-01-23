	public static IDictionary<string, List<object>> TransposeDataTable(DataTable table)
	{
		var dicData = new Dictionary<string, List<object>> ();
		var lstRows = new List<object>[table.Columns.Count];
		foreach (DataRow item in table.Rows) {
			for (var i = 0; i < table.Columns.Count; i++) {
				if (lstRows [i] == null) {
					lstRows [i] = new List<object> ();
				}
				lstRows [i].Add (item [i]); 
			}
		}
		for (var i = 0; i < table.Columns.Count; i++) {
			dicData.Add (table.Columns [i].ColumnName, lstRows [i]);
		}
		return dicData;
	}
