            public void populateProductList()
            {
                string cmdString = "SELECT * FROM PRODUCT";
    
                StockDbConnection dbcon = new StockDbConnection();
                SqlCeConnection Conn = new SqlCeConnection(dbcon.ReturnConnection("ConnString"));
                SqlCeCommand cmd = new SqlCeCommand(cmdString, Conn);
    			DataSet ds;
                try
                {
                    Conn.Open();
    
    				SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
    				da.fill(ds);
    				lstvwProduct.DataSource=ds;
    
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
