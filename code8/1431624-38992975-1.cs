    private void Form1_Load(object sender, EventArgs e)
            {
                string strConnection = "Server=ASHLEY-PC\\SQLEXPRESS;Database=Inventory;Trusted_Connection=true";
    
                SqlConnection con = new SqlConnection(strConnection);
                    
                string query = "select ItemNumber, Name, Cost, QuantityOnHand from Item";
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(query,con );
                DataSet _Bind = new DataSet();
               _Adapter.Fill(_Bind, "MyDataBinding");
               dgInventory.DataContext = _Bind;
    
               con.Close();
            }
