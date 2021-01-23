    protected void SupportSchedule_RowCommand(object sender, GridViewCommandEventArgs e) 
    {
        if (e.CommandName == "EditRow") 
        {
            int rowIndex = ((GridViewRow)((ImageButton) e.CommandSource).NamingContainer).RowIndex;
    
            // Set the index to edit
            SupportScheduleTable.EditIndex = rowIndex;
    
            // Re-bind the GridView to put it in edit mode
            SupportScheduleTable.DataBind();
    
            // Get the row at the index. The row will be the
            // row reflected in edit mode.
            GridViewRow editRow = SupportScheduleTable.Rows[rowIndex];
    
            // Find your DropDownLists in this edit row
            DropDownList ddl1 = editRow.FindControl("ddlshiftmanager") as DropDownList;
            DropDownList ddl2 = editRow.FindControl("ddldispatcherone") as DropDownList;
            DropDownList ddl3 = editRow.FindControl("ddldispatchertwo") as DropDownList;
    
            shift.Enabled = true;
            resourcedate.Enabled = true;
            ListItemCollection c = db.fillList();
    
            if (c != null && ddl1 != null) 
            {
                ddl1.DataSource = c;
                ddl2.DataSource = c;
                ddl3.DataSource = c;
                ddl1.DataBind();
                ddl2.DataBind();
                ddl3.DataBind();
            }
            getSupportSchedule();
        }
        // Everything else...
    }
