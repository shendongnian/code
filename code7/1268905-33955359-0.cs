    string myQuery = "INSERT INTO dbo.contct(name,number,email,city,msg) VALUES(@name, @number, @email, @city, @msg)";
    using (var connection = new SqlConnection("YourConnectionString"))
    {
        using (var cmd = new SqlCommand(myQuery, connection))
        {
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = TextBox1.Text;
            cmd.Parameters.Add("@number", SqlDbType.NVarChar).Value = TextBox2.Text;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = TextBox3.Text;
            cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = TextBox4.Text;
            cmd.Parameters.Add("@msg", SqlDbType.NVarChar).Value = TextArea1.Text;
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    } //Connection closed and disposed autmatically here
