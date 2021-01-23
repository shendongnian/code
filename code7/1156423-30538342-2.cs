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
    						DataTable dt = new DataTable();
							dt.Load(reader);
							dataGridView.AutoGenerateColumns = true;
							dataGridView.DataSource = dt;
							dataGridView.Refresh();
    					}
    				}
    				catch (SqlException Exception)
    				{
    					MessageBox.Show(Exception.ToString());
    				}
    			}
    		}
