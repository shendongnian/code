    string MyConnectionString = "Server=localhost; Database=markcreations; Uid=root; Pwd=admin";
    MySqlConnection connection = new MySqlConnection(MyConnectionString);
    MySqlCommand cmd = new MySqlCommand();
    cmd = connection.CreateCommand();
    cmd.CommandText = "INSERT INTO `customer`(customername,businessname,mobilenumber) values('" + customerName.Text + "','" + businessName.Text + "','" + mobileNumber.Text + "')";
    connection.Open();
    cmd.ExecuteNonQuery();
    cmd.CommandText = ("select Last_insert_id()");
    var id = cmd.ExecuteScalar();
    connection.Close();
    foreach (DataGridViewRow row in dataGridView1.Rows)                   
    {
        try
        {
            cmd = connection.CreateCommand();
            cmd.Parameters.AddWithValue("@last_id", id);
            cmd.Parameters.AddWithValue("@jobName", row.Cells["Job Name"].Value);
            cmd.Parameters.AddWithValue("@flexQuality", row.Cells["Flex Quality"].Value);
            cmd.Parameters.AddWithValue("@sizeLength", row.Cells["Size Length"].Value);
            cmd.Parameters.AddWithValue("@sizeWidth", row.Cells["Size Width"].Value);
            cmd.Parameters.AddWithValue("@rate", row.Cells["Rate"].Value);
            cmd.Parameters.AddWithValue("@quantity", row.Cells["Quantity"].Value);
            cmd.CommandText = "INSERT INTO `order`(customerId,jobName, flexQuality, sizeLength, sizeWidth, rate, quantity)VALUES( @last_id,@jobName, @flexQuality, @sizeLength, @sizeWidth, @rate, @quantity)";
            connection.Open(); // and in the above line i want to insert that variable as values @last_id
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
