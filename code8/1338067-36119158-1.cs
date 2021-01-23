            private void stockdataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            
            }
        
            private void UpdateAndLoad()
            {
        
                string connectionString = @"Server=.\SQLEXPRESS; Database = stock; integrated Security = true";
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "SELECT * FROM stocktable1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Stock> stocks = new List<Stock>();
                while (reader.Read())
                {
                    Stock stock = new Stock();
                    stock.id = (int)reader["id"];
                    stock.gsm = reader["gsm"].ToString();
                    stock.color = reader["color"].ToString();
                    stock.size = reader["size"].ToString();
                    stock.yard = reader["yard"].ToString();
                    stock.meter = reader["meter"].ToString();
                    stock.quantity = reader["quantity"].ToString();
                    stock.supplier = reader["supplier"].ToString();
                    stock.purpose = reader["purpose"].ToString();
                    stock.chalanno = reader["chalanno"].ToString();
                    stocks.Add(stock);
                }
                reader.Close();
                connection.Close();
                stockdataGridView1.DataSource = stocks;
            }
            
            private void Report_Load(object sender, EventArgs e)
            {
                UpdateAndLoad();
            }
            
            private void deletebutton_Click(object sender, EventArgs e)
            {
            
                int id = (int)stockdataGridView1.CurrentRow.Cells["id"].Value;
                string connectionString = @"Server=.\SQLEXPRESS; Database = stock; integrated Security = true";
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "delete from stocktable1 where id=" + id;
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int rowaffected = command.ExecuteNonQuery();
                connection.Close();
                stockdataGridView1.Update();
                stockdataGridView1.Refresh();  
            
                MessageBox.Show("deleted");
                UpdateAndLoad();
            }
