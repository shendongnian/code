    private void _txtFilterEmail_TextChanged(object sender, EventArgs e)
    {
        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
            string.Format("{0} LIKE '%{1}%'",
            dataGridView1.Columns[1].HeaderText.ToString(),
            _txtFilterEmail.Text);
    }
