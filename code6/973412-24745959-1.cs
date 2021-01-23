	protected void rgTest_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
	{
		DataTable batchChecks = new DataTable("checksRandomName");
		batchChecks.Columns.Add("ID");
		batchChecks.Columns.Add("Value");
		batchChecks.Rows.Add(new ArrayList() { "1", "ABC" }.ToArray());
		batchChecks.Rows.Add(new ArrayList() { "2", "BCD" }.ToArray());
		batchChecks.Rows.Add(new ArrayList() { "3", "CDE" }.ToArray());
		batchChecks.Rows.Add(new ArrayList() { "4", "DEF" }.ToArray());
		DataSet dsBatch = new DataSet("rcBatch");
		dsBatch.Tables.Add(batchChecks);
		rgTest.VirtualItemCount = dsBatch.Tables.Count;
		rgTest.DataSource = dsBatch;
	}
	protected void rgTest_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
	{
		if (e.Item is GridDataItem)
		{
			GridDataItem item = (GridDataItem)e.Item;
			TableCell cell = item["Id"];
			switch (cell.Text)
			{
				case "1":
					cell.Controls.Add(new RadComboBox());
					break;
				case "2":
					cell.Controls.Add(new RadNumericTextBox());
					break;
				case "3":
					cell.Controls.Add(new System.Web.UI.WebControls.CheckBox());
					break;
			}
		}
	}
