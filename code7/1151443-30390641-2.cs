    private void button1_Click_1(object sender, EventArgs e)
    {
        dataGridView1.DataSource = null;
        dataGridView1.Rows.Clear();
        dataGridView1.Columns.Clear();
        sudokuTable = getTable();
        dataGridView1.DataSource = sudokuTable;
        for (int i = 0; i < 9; i++)
        {
            dataGridView1.Columns[i].Width = 25 + ((i+1)%3 == 0 ? 5:0);
        }
        dataGridView1.Columns[2].DividerWidth = 5; //Working
        dataGridView1.Columns[5].DividerWidth = 5; //Working
        dataGridView1.Rows[2].DividerHeight = 5; //working?!
        dataGridView1.Rows[5].DividerHeight = 5; //working?!
        dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.ColumnHeadersVisible = false;
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1[0, 0].Selected = false;
    }
