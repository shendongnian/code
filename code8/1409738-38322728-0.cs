    DataTable dt = new DataTable();
            public Form1()
            {
                InitializeComponent();
                dt.Columns.Add("Column1");
                dttest = dt;
            }
    
            public void GetRowOne()
            {
                DataRow dr = dt.NewRow();
                dr["Column1"] = "Test";
                dt.Rows.Add(dr);
    
                dttest = dt;
            }
    
            DataTable dttest { get; set; }
    
            private void button1_Click(object sender, EventArgs e)
            {
                GetRowOne();
            }
