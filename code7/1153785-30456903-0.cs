     protected void OnRowCreated(object sender, GridViewRowEventArgs e)
     {
                subTotal = 0;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;
                    int itemId = Convert.ToInt32(dt.Rows[e.Row.RowIndex]["ItemId"]);
                    total += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["Total"]);
                    if (itemId != currentId)
                    {
                        if (e.Row.RowIndex > 0)
                        {
                            for (int i = subTotalRowIndex; i < e.Row.RowIndex; i++)
                            {
                                Label lblViewTotal = ((Label)e.Row.Cells[6].FindControl("lblViewTotal")) as Label; //First Get label
                                if (lblViewTotal != null && lblViewTotal.Text != string.Empty) //Check whether it is null or not 
                                {
                                    subTotal += Convert.ToDecimal(lblViewTotal.Text);
                                }
    
                            }
                            this.AddTotalRow("Sub Total", subTotal.ToString("N7"));
                            subTotalRowIndex = e.Row.RowIndex;
                        }
                        currentId = itemId;
                    }
                }
      }
