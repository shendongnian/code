     protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataTable mainTable = new DataTable();
            mainTable.Columns.Add("JobID", typeof(int));
            mainTable.Columns.Add("Name");
            mainTable.Columns.Add("Address");
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                mainTable.Rows.Add(rand.Next(1,4), "Name " + i, "Address " + i);
            }
            DataTable jobsTable = new DataTable();
            jobsTable.Columns.Add("JobID", typeof(int));
            jobsTable.Columns.Add("JobName");
            jobsTable.Rows.Add(1, "ABC ");
            jobsTable.Rows.Add(2, "DFG");
            jobsTable.Rows.Add(3, "XCV");
            radGridView1 = new RadGridView() { Dock = DockStyle.Fill, AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill };
            this.Controls.Add(radGridView1);
            radGridView1.EnableFiltering = true;
            radGridView1.DataSource = mainTable; //this will create all columns
            radGridView1.Columns.Remove(radGridView1.Columns["JobId"]);
            GridViewComboBoxColumn comboCol = new GridViewComboBoxColumn();
            comboCol.DataSource = jobsTable;
            comboCol.FieldName = "JobID"; //the name of the field in the main table to look for
            comboCol.DisplayMember = "JobName"; //you want to see job names not ids
            comboCol.ValueMember = "JobID";
            comboCol.FilteringMode = GridViewFilteringMode.DisplayMember;
            radGridView1.Columns.Insert(0, comboCol);
        }
        
        private void radButton1_Click(object sender, EventArgs e)
        {
            radGridView1.Columns["JobID"].FilterDescriptor = new FilterDescriptor
            {
                Operator = FilterOperator.Contains,
                Value = "B"
            };
        }
