    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
         string value = GridView1.Rows[e.NewEditIndex].Cells[3].Text;
         
         // or 
         string value = GridView1.Rows[e.NewEditIndex].Cells[3].Value;
    }
