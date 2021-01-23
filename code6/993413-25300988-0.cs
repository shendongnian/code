	protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox txtProduct = new TextBox();
			txtProduct.ID = "txtProduct";
			txtProduct.Text = (e.Row.DataItem as DataRowView).Row["Product"].ToString();
			e.Row.Cells[1].Controls.Add(txtProduct);
			//Cells[1] IS YOUR TEMPLATE CELL
		}
	}
