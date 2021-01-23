    protected void gridServiceLocations_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != -1)
            {
               
                //Get the value of the current row DataKey
               string dataKey = grid_view.DataKeys[e.Row.RowIndex].Value.ToString();
                //GET THE ROW
                GridViewRow row = e.Row;
                //Now compare it with your value
                if (myValues.Contains(dataKey))
                {
                    //CHECK CASE
                    //The index of column of the column where the checkbox are (1 here, change it )
                    CheckBox checkbox = ((CheckBox)row.Cells[1].FindControl("checkBox"));
                    checkbox.Checked = true;
                }
                else
                {
                    //UNCHECK CASE
                    CheckBox checkbox = ((CheckBox)row.Cells[1].FindControl("checkBox"));
                    checkbox.Checked = false;
                   
                }                
            }
        }
           
