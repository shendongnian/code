            dgv_ClientDetail.DataSource = dt;
            DataGridViewComboBoxColumn dgvCboColumn = new DataGridViewComboBoxColumn();
            dgvCboColumn.Name = "Contacts";
            dgvCboColumn.Items.Add("a");
            dgvCboColumn.Items.Add("b");
            dgvCboColumn.Items.Add("c");
            dataGridView1.Columns.Add(dgvCboColumn);
                      OR
            dgv_ClientDetail.DataSource = dt;
            DataGridViewComboBoxColumn dgvCboColumn = new DataGridViewComboBoxColumn();
            dgvCboColumn.Name = "Contacts";
            dgvCboColumn.DataSource = dtContacts; //DataTable that contains contact details
            dgvCboColumn.DisplayMember = "Name";
            dgvCboColumn.ValueMember = "Id";
            dataGridView1.Columns.Add(dgvCboColumn);
