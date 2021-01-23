            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("EmployeeName", typeof(string));
            gridTable.Columns.Add("StartDate", typeof(DateTime));
            gridTable.Columns.Add("Salary", typeof(double));
            gridTable.Columns.Add("Location", typeof(string));
            dataGridView1.DataSource = gridTable;
