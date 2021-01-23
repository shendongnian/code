    protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      //Accessing BoundField Column
      string name = GridView1.SelectedRow.Cells[0].Text;
 
      txtBLName.Text = name;
    }
