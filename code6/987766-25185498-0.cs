        dataGridView1.AllowUserToOrderColumns = true;
        DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
        cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        // Replace this
        //dataGridView1.AlternatingRowsDefaultCellStyle = cellStyle;
        // With this
        dataGridView1.DefaultCellStyle = cellStyle;
        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
        for (int i = 0; i < 10; i++)
        {
            dataGridView1.Rows.Add(1, "Test", 14, "Long String With Spaces");
        }
