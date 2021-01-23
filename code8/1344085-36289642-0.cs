        private void DataGridViewJobs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            string colName = "Jobs";
            if (dataGridViewJobs.Columns.Contains(colName))
            {
                dataGridViewJobs.Columns.Remove(colName);
            }
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Name = colName;
            dataGridViewJobs.Columns.Add(column);
    
            foreach (DataGridViewRow row in dataGridViewJobs.Rows)
            {
                var person = (Person)row.DataBoundItem;
                var cell = row.Cells[colName] as DataGridViewComboBoxCell;
    
                cell.DataSource = person.Jobs;
                cell.Value = person.Jobs[0];
            }
        }
