        OleDbConnection Cons = new OleDbConnection(); // new connection 
        OleDbDataReader dr;
        int currentRow = 0;
        //Location
        DataTable dt = new DataTable();
        OleDbDataAdapter da;
        //Product
        DataTable dt1 = new DataTable();
        OleDbDataAdapter da1;
        //staff
        DataTable dt2 = new DataTable();
        OleDbDataAdapter da2;
        //Assign
        DataTable dt3 = new DataTable();
        OleDbDataAdapter da3;
        private void Assign_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = ConnectionDetail.Warehouse;
                string sql = "Select * from Location";
                da = new OleDbDataAdapter(sql, conn);
                da.Fill(dt); // filling the database information into databtable
                
                //Location Table
                DataRow dr = dt.Rows[currentRow]; // counting the rows
                txtLocID.Text = dr["Location ID"].ToString();
                txtAisle.Text = dr["Aisle Code"].ToString(); 
                txtSection.Text = dr["Section"].ToString();
                txtShelf.Text = dr["Shelf"].ToString();
                txtLocation.Text = dr["Location"].ToString();
                txtLength.Text = dr["Length"].ToString();
                txtWidth.Text = dr["Width"].ToString();
                lstSize.Text = dr["Size Description"].ToString();
                //Product Table
                OleDbConnection conn1 = new OleDbConnection();
                conn1.ConnectionString = ConnectionDetail.Warehouse;
                string sql1 = "Select * from Products";
                da1 = new OleDbDataAdapter(sql1, conn1);
                da1.Fill(dt1); // filling the database information into databtable
                DataRow dr1 = dt1.Rows[currentRow]; // counting the rows
                txtSKU.Text = dr1["SKU"].ToString();
                txtDes.Text = dr1["Description"].ToString(); 
                listHaz.Text = dr1["Hazardous"].ToString();
                listLiq.Text = dr1["Liquid"].ToString();
                txtQuan.Text = dr1["Quantity"].ToString();
                txtWeig.Text = dr1["Weight"].ToString();
                lstSize1.Text = dr1["Size Description"].ToString();
                //Staff Table
                OleDbConnection conn2 = new OleDbConnection();
                conn2.ConnectionString = ConnectionDetail.Warehouse;
                string sql2 = "Select * from Staff";
                da2 = new OleDbDataAdapter(sql2, conn2);
                da2.Fill(dt2); // filling the database information into databtable
                DataRow dr2 = dt2.Rows[currentRow]; // counting the rows
                txtID.Text = dr2["StaffID"].ToString();
                
                //Assign Table
                OleDbConnection conn3 = new OleDbConnection();
                conn3.ConnectionString = ConnectionDetail.Warehouse;
                string sql3 = "Select * from Assign";
                da3 = new OleDbDataAdapter(sql3, conn3);
                da3.Fill(dt3); // filling the database information into databtable
                DataRow dr3 = dt3.Rows[currentRow]; // counting the rows
                txtAssID.Text = dr3["Assign ID"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            {
                OleDbConnection load = new OleDbConnection();
                load.ConnectionString = ConnectionDetail.Warehouse;
                OleDbCommand cmds = new OleDbCommand();
                lbltime.Text = DateTime.Now.ToString("yyyy MMM ddd HH:mm");
                try
                {
                    load.Open();
                    cmds = new OleDbCommand();
                    cmds.CommandText = "SELECT * FROM Location;";
                    cmds.CommandText = "SELECT * FROM Products;";
                    cmds.CommandText = "SELECT * FROM Staff;";
                    cmds.CommandText = "SELECT * FROM Assign;";
                    cmds.Connection = load;
                    dr = cmds.ExecuteReader();   
                      
                }
                catch (Exception err)
                {
                    //Any database errors jump here and output error message
                    MessageBox.Show("A database error has occurred: " + Environment.NewLine + err.Message);
                }
                finally
                {
                   // btnNext_Click(sender, e);
                    txtLocID.Visible = false;
                }
            }
        }
 
