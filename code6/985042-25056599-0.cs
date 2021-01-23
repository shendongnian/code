    private void textBox1_TextChanged(object sender, EventArgs e)
    {
       //Use could set the SelectionMode within FormLoad as well.
       dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
       dataGridView1.ClearSelection();
    
       foreach (DataGridViewRow item in dataGridView1.Rows)
       {
          if (item.Cells[0].Value.ToString().Equals(textBox1.Text))
          {
              item.Selected = true;
          }
       }
    }
