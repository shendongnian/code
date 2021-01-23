    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        int ID = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
        string columnName = (row.Cells[2].Controls[0] as TextBox).Text;
        string dataType = (row.Cells[3].Controls[0] as DropDownList).Text;
    
        // edit DataTable...
    }
