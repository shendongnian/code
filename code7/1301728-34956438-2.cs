    protected void deleteRow()
    {
        DataTable dt = new DataTable(); 
        //add code to create column for this data table
        //only set column for textbox columns
        dt.Columns.Add("Column1", typeof(string));
        table.Columns.Add("Column2", typeof(string));
        table.Columns.Add("Column3", typeof(string));
               
        //build a data source of existing rows
        foreach (GridViewRow gridRow in grid1.Rows)
        {
            //get whether the checkbox for deleting row is checked or not
            CheckBox chkDelete = gridRow.FindControl("chkDelete") as CheckBox;
            //do not add original row if it was checked to be deleted
            if(!chkDelete.Checked)
             {
               dr = dt.NewRow();
            
               //set only text box values in new data source
               //so checkbox column for row selection will be ignored
               TextBox txtColumn1 = gridRow.FindControl("txtColumn1") as TextBox;
               TextBox txtColumn2 = gridRow.FindControl("txtColumn2") as TextBox;
               TextBox txtColumn3 = gridRow.FindControl("txtColumn3") as TextBox;
    
               dr[0] = txtColumn1.Text;
               dr[1] = txtColumn2.Text;
               dr[2] = txtColumn3.Text;
    
               dt.Rows.Add(dr); 
           }
        }
       
        //bind the grid view, which will now NOT have the deleted rows
        grd.DataSource = dt; 
        grd.DataBind();
    }
