            dataGridView1.DataSource = dt;
            DataGridViewComboBoxColumn dgvCboColumn = new DataGridViewComboBoxColumn();
            dgvCboColumn.Items.Add("a");
            dgvCboColumn.Items.Add("b");
            dgvCboColumn.Items.Add("c");
            dataGridView1.Columns.Add(dgvCboColumn);
