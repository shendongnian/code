private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
{               
   foreach (DataGridViewRow row in dataGridView1.Rows)
   {
      int rowGroup = 0;
      int.TryParse(row.Cells["groupName"].Value.ToString().Last().ToString(), out rowGroup);
      if (rowGroup % 2 == 0)
         row.DefaultCellStyle.BackColor = Color.White;
      else
         row.DefaultCellStyle.BackColor = Color.DarkGray;
   }
}
