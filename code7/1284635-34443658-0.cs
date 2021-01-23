	// Change decimal places and pass the DataTable to the GridView
	for (int i = 0; i < dt.Rows.Count; i++)
	{
		double newValue = Convert.ToDouble(dt.Rows[i]["ColumnNameToChange"]);
		dt.Rows[i]["ColumnNameToChange"] = String.Format("{0:N" + GridRoundoffDecimal.ToString() + "}", newValue);
	}
	GridView1.DataSource = dt;
	GridView1.DataBind();
