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
                    StringBuilder sb = new StringBuilder();
    
                    while (dr.Read())
                    {
                        if (sb.Length > 0) 
                            sb.AppendLine();
    
                        sb.Append(String.Format("{0}, {1}", dr.GetValue(0), dr.GetValue(1)));
                    } 
    
                    TB_PRODUCTS.Text = sb.ToString();
                }
    
            }
    
        }
