            comm2 = new SqlCommand("insert into Addresses(Street, City, aState, Zip) values (@Street, @City,@aState, @Zip)", conn);
            comm2.Parameters.Add("@Street", SqlDbType.NVarChar).Value = streetTextBox.Text;
            comm2.Parameters.Add("@City", SqlDbType.NVarChar).Value = cityTextBox.Text;
            comm2.Parameters.Add("@aState", SqlDbType.NVarChar).Value = aStateTextBox.Text;
            comm2.Parameters.Add("@Zip", SqlDbType.NVarChar).Value = zipTextBox.Text;
            try
            {
                comm.ExecuteNonQuery();
                comm2.ExecuteNonQuery();
                MessageBox.Show("Saved...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
