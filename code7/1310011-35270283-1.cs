    if (dataGridView1.DataSource != null)
    {
        dataGridView1.Columns["idColumn1"].HeaderText = "Text 1";
        dataGridView1.Columns["idColumn1"].Width = 60;
        dataGridView1.Columns["idColumn1"].Index = 0;
     
        dataGridView1.Columns["idColumn2"].HeaderText = "Text 2";
        dataGridView1.Columns["idColumn2"].Width = 60;
        dataGridView1.Columns["idColumn2"].Index = 1;
        dataGridView1.Columns["idColumn3"].HeaderText = "Text 3";
        dataGridView1.Columns["idColumn3"].Width = 60;
        dataGridView1.Columns["idColumn3"].Index = 2;
        dataGridView1.Columns["idColumn4"].Visible= false;
        dataGridView1.Columns["idColumn5"].Visible= false;
        dataGridView1.Columns["idColumn6"].Visible= false;
    }
