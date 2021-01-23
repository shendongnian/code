        String sql = "SELECT * FROM products where code = '"+textBox1.Text + "'";
        SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn); //c.con is the connection string
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
              conn.Open();
              using (SqlDataReader reader = cmd.ExecuteReader())
              {
                    while(reader.Read())
                    {
                        listBox1.Items.Add(reader["description"].ToString() + ":    "+reader["price"].ToString());
                    }
                    reader.Close();                   
               }
               conn.Close();
         }
