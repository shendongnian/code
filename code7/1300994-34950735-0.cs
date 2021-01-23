      private void button1_Click(object sender, EventArgs e) {
         dataGridView1.Columns.RemoveAt(1);
      }
      private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e) {
         e.Column.HeaderText = e.Column.DisplayIndex.ToString();
      }
