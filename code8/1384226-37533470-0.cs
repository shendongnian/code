    private void button1_Click(object sender, EventArgs e)
    {
        int i_xyz = 0, j_xyz = 0;   // Drew added
        try
        {
            SqlConnection con = new SqlConnection("Data Source=localhost\\DEV;Initial Catalog=db;Integrated Security=True");
            var f_id = textBox2.Text;  //Unique ID Not used to generate all tickets
            var n_copies = textBox1.Text; //Number of copies default 1
            var t_per_acre = textBox3.Text; //Set default at 2 Tickets per acre
            string sql = "Select * From dbo.CParcel";   // STARTING POINT A
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "CParcel");
            foreach (DataRow theRow in ds.Tables["CParcel"].Rows)
            {
                i_xyz++;    // Drew added
                decimal get_acreage = System.Convert.ToDecimal(theRow["ACREAGE"]);
                int acr = (int)(get_acreage + 0.5m);
                int t_t_per_acr = acr * System.Convert.ToInt32(t_per_acre);
                int t_t_per_acr_per_copy = t_t_per_acr * System.Convert.ToInt32(n_copies);
                for (int i = 1; i < t_t_per_acr_per_copy; i++)
                {
                    j_xyz++;    // Drew added
                    sql = sql + " Union All SELECT * FROM dbo.CParcel";
                }
            }
            // POINT B <------------------
    
            // STOP !!
            // RIGHT HERE what is the value of i_xyz and j_xyz ?? In particular j_xyz
            // also flush sql out to a text file and get a good look at it
    
            //SqlDataAdapter tsda = new SqlDataAdapter(sql, con);
            //DataSet ds2 = new DataSet();
            //tsda.Fill(ds2, "CParcel");
            //crystal.SetDataSource(ds2);
            //crystal.SetDatabaseLogon("sa", "password");
            //crystalReportViewer1.ReportSource = crystal;
    
        }
        catch (Exception ex)
        {
            // Print error message
            MessageBox.Show(ex.Message);
        }
    }
