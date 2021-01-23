    string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    string connectionString = con;
    foreach (var item in comboBox1.Items) //loop to go through the items one by one
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO JobRoles (Jobroles) VALUES (@jr)");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@jr", item.ToString()); //Add each item to database separately 
            
            connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Datebase error. Please contact software engineer.", "Error 303");
                return;
            }
        }
    }
