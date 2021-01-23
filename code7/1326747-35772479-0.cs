        private void Form1_Load(object sender, EventArgs e)
        {
            string[] tableColumns = new string[] { "A", "B", "C", "D" };
            string[] fileColumns = new string[] { "A", "B", "C", "X" };
            dgv.DataSource = tableColumns.Select(x => new { Value = x }).ToList();
            dgv.Columns[0].HeaderText = "Table Columns";
            DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
            comboColumn.HeaderText = "File Columns";
            foreach (var item in fileColumns)
                comboColumn.Items.Add(item);
            dgv.Columns.Add(comboColumn);
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string tableColumnValue = row.Cells[0].Value.ToString();
                //Change is here
                if (fileColumns.Any(i => i == tableColumnValue))
                {
                    row.Cells[1].Value = tableColumnValue;
                }
                //end change
            }
        }
