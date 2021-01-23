    using (MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(sql, DataUtils.ConnectionStrings["TAT"]))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.CommandText = query;
                adapter.Fill(dt);
                ds.Tables.Add(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.DataBind();
            }
    
