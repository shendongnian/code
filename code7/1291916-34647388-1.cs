    try
    {
        using (var con = new OleDbConnection())
        {
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\esoft\gym\gym\bin\Debug\Clients.accdb;";
            con.Open();
            using (var com = new OleDbCommand())
            {
                com.Connection = con;
                com.CommandText = "INSERT INTO gym ([BMI],[Health],[weight_change_to_healthy_bmi]) VALUES (@bmi,@health,@weight)";
                com.Parameters.AddWithValue("@bmi", textBox5.Text);
                com.Parameters.AddWithValue("@health", textBox6.Text);
                com.Parameters.AddWithValue("@weight", textBox4.Text);
                com.ExecuteNonQuery();
            }
        }
        MessageBox.Show("Saved");
    }
    catch (Exception ex)
    {
        MessageBox.Show("Not saved: " + ex.Message);
    }
