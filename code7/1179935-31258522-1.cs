    void ctlGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView item = (DataRowView)e.Row.DataItem;
                //get value of Color from the bound data
                string color = item["Color"].ToString();
                //make sure that the casing (i.e., lower, upper or proper) of each checkbox ID matches what's in the DB
                ((CheckBox)e.Row.FindControl(color)).Checked = true;
                
            }
        }
