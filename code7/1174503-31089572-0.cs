     private void Form1_Load(object sender, EventArgs e)
       {
      this.dataGridView1.EditingControlShowing += new    DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
     }
     void dataGridView1_EditingControlShowing(object sender, 
     DataGridViewEditingControlShowingEventArgs e)
        {
         if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = (TextBox)e.Control;
                tb.TextChanged += new EventHandler(tb_TextChanged);
            }
         }
 
         void tb_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("changed");
        }
