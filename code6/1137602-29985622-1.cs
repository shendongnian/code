        private void button1_Click(object sender, EventArgs e)
        {
            string excelconn = ConfigurationManager.ConnectionStrings["MSIDConn"].ConnectionString;
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = excelconn;
               
            OleDbCommand command9 = new OleDbCommand
            (
                "SELECT P1, P2, P3, Product_Type ,City ," +
                "CC_Volume  ,PD_Volume ,CC_Percent ,WE_Volume  ,WE_Percent ,ME_Volume  ,ME_Percent ,MTD_Growth ,YE_Volume  ,YE_Percent ,YTD_Growth " +
                  " FROM [PE_Actual$] ", conn
            );
            DataSet ds9 = new DataSet();
            OleDbDataAdapter adaptor9 = new OleDbDataAdapter(command9);
            adaptor9.Fill(ds9, "PE_Actual");
            dataGridView1.DataSource = ds9.Tables[0].DefaultView;
           
        }
