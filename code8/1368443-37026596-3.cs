    private void _txtFilterEmail_TextChanged(object sender, EventArgs e)
    {
         BindingSource bs = new BindingSource();
         bs.DataSource = dataGridView1.DataSource;
         bs.Filter = string.Format("[{0}] LIKE '%{1}%'",
         dataGridView1.Columns[1].HeaderText.ToString(), _txtFilterEmail.Text);
         dataGridView1.DataSource = bs;
    }
