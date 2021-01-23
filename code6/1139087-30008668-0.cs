    protected void GridViewDisplay_RowCommand(object sender,
     GridViewCommandEventArgs e)
     {
     if (e.CommandName == "AddToCart")
     {
     object[] values;
            DataTable orderTable;
            // Retrieve the row index stored in the 
            // CommandArgument property.
            int index = Convert.ToInt32(e.CommandArgument);
    
            // Retrieve the row that contains the button 
            // from the Rows collection.
            GridViewRow row = GridViewDisplay.Rows[index];
            values = new Object[GridViewDisplay.Rows[0].Cells.Count];
            for (int i = 0; i < GridViewDisplay.Rows[0].Cells.Count; i++)
            {
                values[i] = row.Cells[i].Text;
            }
    
           orderTable = (DataTable)Session["OrderLine"];
           orderTable.Rows.Add(values);
           Session["OrderLine"] = orderTable;
    
    
        }
    
    }
