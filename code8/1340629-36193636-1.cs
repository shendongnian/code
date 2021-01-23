	protected void grdmaster_ItemDataBound(object sender, GridItemEventArgs e)
	{
		if (e.Item is GridFooterItem)
		{
			GridDataItem item = (GridDataItem)e.Item;
			
			TextBox txtdebit1 = item.FindControl("txtdebit1") as TextBox;
			TextBox txtcredit2 = item.FindControl("txtcredit2") as TextBox;
			
			TableCell cell = (TableCell)txtdebit1.Parent;
			
			CompareValidator val = new CompareValidator();
			val.ControlToCompare = txtcredit2.ID;
			val.ControlToValidate = txtdebit1.ID;
			val.Operator = ValidationCompareOperator.LessThan;
			val.Display = ValidatorDisplay.Dynamic;
			val.ErrorMessage = "Error message";
			cell.Controls.Add(val); 
			
		}
	}
