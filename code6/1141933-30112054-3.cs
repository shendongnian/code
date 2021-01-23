    public Form1()
    {
      InitializeComponent();
      listView1.View = View.Details;
      listView1.Columns.Add("Column");
      listView1.Columns.Add("Row");
      listView1.Columns.Add("Value");
    }
    private void button2_Click(object sender, EventArgs e)
    {
      button2.Text = "Find All";
      int tempIndex = -1;
      listView1.Items.Clear();
      for (int i = 0; i < dataGridView1.Rows.Count; i++)
      {
        tempIndex = (tempIndex + 1) % dataGridView1.Rows.Count;
        DataGridViewRow row = dataGridView1.Rows[tempIndex];
        if (row.Cells["Foo"].Value == null)
        {
          continue;
        }
        if (row.Cells["Foo"].Value.ToString().Trim().Contains(textBox1.Text))
        {
          DataGridViewCell cell = row.Cells["Foo"];
          ListViewItem lvRow = new ListViewItem(new string[] { cell.ColumnIndex.ToString(), cell.RowIndex.ToString(), cell.Value.ToString() });
          listView1.Items.Add(lvRow);
        }
      }
    }
