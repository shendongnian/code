    using (MySqlConnection con= new MySqlConnection(connectionString))
        {
            try
            {
                con.Open();
                label1.Text = "Connection Established!";
            }
            catch(Exception ex)
            {
                label1.Text = "Connection Error!\n"+ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
