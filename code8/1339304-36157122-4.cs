        public void Fillcombobox()
        {
            //TODO: do not hardcode connection string (esp. password), but load it
            string connstr = "data source=db;user id=user;password=pwd;";
            string cmdtxt = 
              @"select product_id, 
                       description 
                  from products";
    
            using (OracleConnection conn = new OracleConnection(connstr))
            using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
            {
                conn.Open();
    
                // reader is IDisposable and should be closed
                using (OracleDataReader dr = cmd.ExecuteReader()) 
                {
                    List<String> items = new List<String>();
    
                    while (dr.Read())
                    {
                        items.Add(String.Format("{0}, {1}", dr.GetValue(0), dr.GetValue(1)));
                    } 
    
                    TB_PRODUCTS.Items.AddRange(items);
                }
    
            }
    
        }
