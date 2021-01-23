    private void searchBox_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = string.Format(columnChoice.Text + " LIKE '*{0}*'", searchBox.Text.Trim().Replace("'","''"));
            dataGridView1.DataSource = bs;
        }
