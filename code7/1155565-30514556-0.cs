    protected void Button2_Click(object sender, EventArgs e)  {
      int intfemdelegates = 0;
  
        foreach(GridViewRow oItem in GridView1.Rows) {
         if (oItem.Cells[6].Text.Contains('F')) {
           intfemdelegates = intfemdelegates + 1;
           oItem.BackColor = System.Drawing.Color.Red;
     }
       Label2.Text = Convert.ToString(intfemdelegates);
      }
