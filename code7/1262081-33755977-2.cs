	public DataTable RecursiveTreeTable(DataTable table, String parentNode, String dataColumn)
	{
		ParentNodeColumnName = parentNode;
		DataColumnName = dataColumn;
		TblTree = table.Copy();
		TblTree.Clear();
		if (table.Rows.Count > 0)
		{
			foreach (DataRow dr in table.Rows)
			{
				var desRow = TblTree.NewRow();
				desRow.ItemArray = dr.ItemArray.Clone() as object[];
				desRow["Values"] = SumOfValuesForAllChildren(dr, table);
			}
		}
		return TblTree;
	}
	public int SumOfValuesForAllChildren(DataRow parentRow, DataTable table)
	{
		var parentID = Convert.ToInt64(parentRow["Id"]);
		// start with the parent value.
		var result = Convert.ToInt32(parentRow["Values"]);
		
		foreach (DataRow dr in table.Rows)
		{
			var childParentId = Convert.ToInt64(dr["ParentNodeId"]);
			if (childParentId == parentID)
                // add the child values
				result += SumOfValuesForAllChildren(dr, table);
			
		}
		return result;
	}
