            dgvMain.DataSource = bulkImportTable;
            CalendarColumn col = new CalendarColumn();
            col.Name = "DeployDate";
            dgvMain.Columns.Remove("DeployDate");
            dgvMain.Columns.Add(col);
            
            col.DataPropertyName = col.Name;
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                row.Cells[dgvMain.Columns.Count - 1].Value = DateTime.Now.ToShortDateString();
            }
