    public void buttonclick(object sender,eventArgs e)
    {
    	var connectionString = ConfigurationManager.ConnectionStrings["BUM"].ConnectionString;
    	
    	using(SqlConnection con0 = new SqlConnection(connectionString))
    	{
    		con0.Open();
    		using(SqlCommand cmd = new SqlCommand("book_master_insert", con0))
    		{
    			cmd.CommandType = CommandType.StoredProcedure;				
    			cmd.Parameters.AddWithValue("@customer_id", cust_id);
    			cmd.Parameters.AddWithValue("@booking_from", ddlfrom.SelectedItem.Text);
    			cmd.Parameters.AddWithValue("@booking_destination", ddlto.SelectedItem.Text);
    			cmd.Parameters.AddWithValue("@load_type", ddlLoadtype.SelectedItem.Text);
    			cmd.Parameters.AddWithValue("@no_of_containers", txt_no_of_container.Text);
    			cmd.Parameters.AddWithValue("@booking_pickupdate", txt_date.Text);
    			cmd.Parameters.AddWithValue("@booking_pickuptime", txt_time.Text);
    			cmd.Parameters.AddWithValue("@booking_createdate", localDate);	       		
    			cmd.ExecuteNonQuery();
    			
    			// This is a BAD idea and you should replace this using parametrized queries
    			using(SqlCommand cmd2 = new SqlCommand("select booking_ID from booking_master where customer_id='"+cust_id+"' and booking_from='" + ddlfrom.SelectedItem.Text + "'and booking_destination='" + ddlto.SelectedItem.Text + "' and load_type='" + ddlLoadtype.SelectedValue + "' and no_of_containers='" + txt_no_of_container.Text + "' and CAST (booking_pickupdate as date) ='" + txt_date.Text + "' and booking_pickuptime='" + txt_time.Text + "';", con2))
    			{		
    				using(SqlDataReader rdr = cmd2.ExecuteReader())
    				{		
    					while (rdr.Read())
    					{
    						booking_ID = rdr["booking_ID"].ToString();
    					}
    				}
    			}
    		}
    	}
    }
