    private void createorderButton_Click(object sender, EventArgs e)
            {
                SqlConnection myConnection = dbHelper.initiallizeDB();
                String query = "INSERT INTO testtabel (knaam, korder) VALUES ('" + knaamTextBox.Text + "','" + kordernrTextBox.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(query, myConnection);
                SqlCommand cmd = new SqlCommand("select * from testtabel where korder = @korder", myConnection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@korder";
                param.Value = kordernrTextBox.Text;
                //sqlCommand.Connection.Open();
               
    			SqlDataReader cmdReader = sqlCommand.ExecuteReader();
                if (cmdReader.HasRows)
                {
                    MessageBox.Show("Order already exist");
    
                }
                else
                {
                    cmdReader.Close();
                }
    			
    			SqlDataReader reader = sqlCommand.ExecuteReader();
                // opens execute non query 
                int rows_inserted = sqlCommand.ExecuteNonQuery();
    
                if (rows_inserted > 0)
                {
                    label2.Text = "Order has been created";
                }
    
                else
                {
                    Console.Write("Oops! Something wrong!");
    
                }
    
    
    
            }
