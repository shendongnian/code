    void textBox1_TextChanged(object sender, EventArgs e)
    {
      PopulateGrid(textBox1.Text);
    }
    void PopulateGrid(string queryStr)
    {
      dataGridView1.DataSource = _journal.GetSearchResults(queryStr);
      SetStatus(dataGridView1.Rows.Count); // Change status bar (not shown)
    }
