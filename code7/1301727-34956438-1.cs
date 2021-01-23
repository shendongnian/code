    protected void addRow()
    {
        DataTable dt = new DataTable(); 
        //add code to create columns for this data table
        //only create columns for textbox data
        dt.Columns.Add("Column1", typeof(string));
        table.Columns.Add("Column2", typeof(string));
        table.Columns.Add("Column3", typeof(string));
        DataRow dr = null;
       
        //build a data source of existing rows
        foreach (GridViewRow gridRow in grid1.Rows)
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
    
        //create the row in data sourec for the new grid row
        dr = dt.NewRow(); 
        dt.Rows.Add(dr);
    
        //bind the grid view, which will now show you the new added row in addition to original rows
        grd.DataSource = dt; 
        grd.DataBind();
    }
