      private void button1_Click(object sender, EventArgs e)
      {
          StringBuilder ln = new StringBuilder();
          dataGridView1.ClearSelection();
          foreach (DataGridViewRow row in dataGridView1.Rows)
          {
              if (((bool?)row.Cells[0].Value) == true)
              {
                   ln.Append(row.Cells[1].FormattedValue);
              }
          }
          if (ln.Length <= 0) MessageBox.Show("No rows are checked!");
          else MessageBox.Show("Rows content: " + ln);
     }
