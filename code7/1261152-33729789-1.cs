     protected void Button1_Click(object sender, EventArgs e)
        {
               string connectionString = "Persist Security Info=False;User ID=sa;Password=123;Initial Catalog=AddressBook;Server=abc-PC";    
        using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblName ([Name], Address) VALUES (@Name, @Address)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
            }     
        }
