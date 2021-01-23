	StringBuilder finalString = new StringBuilder();
	for (int i = 0; i < dataTable.Rows.Count; i++)
    {
        DataRow myRow = dataTable.Rows[i];
        foreach(object item in myRow.ItemArray)
		{
			if(item is int)
			{
				finalString.Append(item.ToString());
			}
			else
			{
				//Error
			}
		}
		finalString.Append(";");
	}
	
	//TODO Write here your query where you store the finalString.ToString() in the DB
	
	
