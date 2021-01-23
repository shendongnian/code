    private int searchIndex = -1;
    private void button1_Click(object sender, EventArgs e)
    {
      button1.Text = "Find Next";
      for (int i = 0; i < dataGridView1.Rows.Count; i++)
      {
        searchIndex = (searchIndex + 1) % dataGridView1.Rows.Count;
        DataGridViewRow row = dataGridView1.Rows[searchIndex];
        if (row.Cells["Foo"].Value == null)
        {
          continue;
        }
        if (row.Cells["Foo"].Value.ToString().Trim() == textBox1.Text)
        {
          dataGridView1.CurrentCell = row.Cells["Foo"];
          dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[row.Index].Index;
          return;
        }
      }
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      searchIndex = -1;
    }
