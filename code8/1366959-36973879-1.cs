    public int SearchCar(MainStore searchCars)
        {
                string connection = @"Data Source=(LocalDB)";
                SqlConnection con = new SqlConnection(connection);
                string sql = string.Format("SELECT car, model, year FROM store WHERE {0} like @search", search.GetCombo());
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
    
               // sdt.SelectCommand.Parameters.AddWithValue("@column", "%" + search.GetCombo());
                sdt.SelectCommand.Parameters.AddWithValue("@search", "%" + search.GetSearch());
    
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = data;
         }
