        public Form2()
        {
            InitializeComponent();
            //You may don't need to do this part. You may can fetch the data from the database
            /////////////////////// To Disaplay Data On the DataGrid /////////////////
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Country");
            dt.Rows.Add("Supun", "+940711288825", "Sri Lanka");
            dt.Rows.Add("Nimantha", "+940783193677", "Sri Lanka");
            dataGridView1.DataSource = dt;
            ////////////////////////////////////////////////////////////////////////
            // To avoid select multiple rows at once
            dataGridView1.MultiSelect = false;
        } 
