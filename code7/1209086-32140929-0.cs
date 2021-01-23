        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridView datagrid = new DataGridView();
            DataTable dt = new DataTable();
            //add this line
            Controls.Add(datagrid);
            
            dt.Columns.Add("No");
            dt.Columns.Add("Name");
            for (int i = 1; i <= 10; i++)
            {
                DataRow row = dt.NewRow();
                row[0] = i;
                row[1] = "ABC";
                dt.Rows.Add(row);
            }
            datagrid.DataSource = dt;
            dt.Rows[0][1] = "XYZ";
        }
