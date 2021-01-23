            dgv_ClientDetail.DataSource = new DataView(dt)
                                             .ToTable(true, new string[] { "Name", "City" });
            DataGridViewComboBoxColumn dgvCboColumn = new DataGridViewComboBoxColumn();
            dgvCboColumn.Name = "Contacts";
            dgv_ClientDetail.Columns.Add(dgvCboColumn);
            foreach (DataGridViewRow row in dgv_ClientDetail.Rows)
            {
                DataGridViewComboBoxCell cboContacts = (DataGridViewComboBoxCell)(row.Cells["Contacts"]);
                cboContacts.DataSource = //Get the contact details of a person,
                                         //using his Name or Id field (row.Cells["Name"]);
                cboContacts.DisplayMember = "Name"; //Name column of contact datasource
                cboContacts.ValueMember = "Id";//Value column of contact datasource
            }
