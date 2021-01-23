    public void customerSearch(int custID, DataGridView dataGridView)
    		{
    			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
    			{
    				try
    				{
    				
    					connection.Open();
    
    					SqlCommand searchQuery = new SqlCommand("select * from [Customer] where custId = @custID", connection);
    					searchQuery.Parameters.Add("@custId", SqlDbType.Int).Value = custID;
    					//searchQuery.ExecuteNonQuery();
    
    					using (SqlDataReader reader = searchQuery.ExecuteReader())
    					{
    						while (reader.Read())
    						{
    							dataGridView.DataBindings.ToString();
    						}
    					}
    				}
    				catch (SqlException Exception)
    				{
    					MessageBox.Show(Exception.ToString());
    				}
    			}
    		}
