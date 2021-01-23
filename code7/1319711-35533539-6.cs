    String check = "SELECT * FROM Companies WHERE Name=@name";
    using (SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=ABCD;Integrated Security=True"))
    using (SqlCommand cmd = new SqlCommand(check, con))
    {
      con.Open();
      cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();
      SqlDataReader reader = cmd.ExecuteReader();
      while (reader.Read())
      {
           textBox1.Text = reader["Name"].ToString();
           textBox2.Text = reader["PhNo"].ToString();
           textBox3.Text = reader["Email"].ToString();
           textBox4.Text = reader["Acc"].ToString();
           textBox5.Text = reader["Address"].ToString();
           textBox6.Text = reader["Suburb"].ToString();
           textBox7.Text = reader["PostCode"].ToString();
           textBox8.Text = reader["State"].ToString();
       }
    }
