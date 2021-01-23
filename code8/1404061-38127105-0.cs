	var mb= new StringBuilder();
	foreach (object dataItem in r.ItemArray)
	{
		if (dataItem != null) // This will check the null values also 
		{
			mb.Append(dataItem.ToString());
		}
		else
		{
			mb.Append("(null)");		
		}
	    mb.Append(" ");
	}
	MessageBox.Show(mb.ToString());
