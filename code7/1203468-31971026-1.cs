        string binValue;
        int idHolder = ItemType1.SelectedValue;
            con.ConnectionString =System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString_GRPAS_dev"].ConnectionString;
                  {
                   using (OleDbCommand cmd = new OleDbCommand("SELECT BinType FROM NF_WhatWasteWhere WHERE ID = @Id;"))
                    {
                      cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id",idHolder);
                      cmd.Connection = con;
            
                      con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
              if(!DBNull.Value.Equals(reader["BinType"]))
                {
                 binValue = Convert.ToString(reader["BinType"]);
                 }
           }
         con.Close();
    
    //Then all your conditionals based off of binValue....
