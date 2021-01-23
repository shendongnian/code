	public void MasterChanged(long masterID)
	{
		var currencyManager = bindingContext[dataModel.DataSet, "Master"];
		var masterRows = masterTable.Rows;
		for (int position = 0; position < masterRows.Count; position++)
		{
			if (((long)masterRows[position]["ID"]) == masterID)
			{
				currencyManager.Position = position;
				break;
			}
		}
	}
