        public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Message Subject");
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr[dc] = "test";
            DataRow dr1 = dt.NewRow();
            dr1[dc] = "test123";
            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            this.dataGridView1.DataSource = dt;
        }
