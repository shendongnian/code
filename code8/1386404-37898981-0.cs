            SqlConnection con = new SqlConnection("Server=YourServerName;Database=YourDataBaseName;Trusted_Connection=True"); 
            
            try
            {
                //cmd new SqlCommand( "UPDATE Stocks 
                //SET Name = @Name, City = @cit Where FirstName = @fn and LastName = @add";
                cmd = new SqlCommand("Update Stocks set Ask=@Ask, Bid=@Bid, PreviousClose=@PreviousClose, CurrentOpen=@CurrentOpen Where Name=@Name", con);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Ask", textBox2.Text);
                cmd.Parameters.AddWithValue("@Bid", textBox3.Text);
                cmd.Parameters.AddWithValue("@PreviousClose", textBox4.Text);
                cmd.Parameters.AddWithValue("@CurrentOpen", textBox5.Text);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
