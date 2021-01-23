    private void btn_Click(object sender, RoutedEventArgs e)
    {
        SqlConnection con = new SqlConnection("server = localhost; database= test;Integrated Security = true");
        SqlCommand cmd = new SqlCommand("SELECT * FROM table WHERE name = @name");
        cmd.Parameters.AddWithValue("@name", txt.Text);
        con.Open();
        SqlDataReader reader = myCommand.ExecuteReader();
        while(reader.Read())
        {
            if(Convert.ToInt32(reader["quantity"].ToString()) > 0)
            {
                cmd.CommandText = "Update so set quantity where quantity = 0  And name Like '%' + @name + '%'";
            }
            else
            {
                MessageBox.Show("There isn't any part left that you are looking for");
            }
        }
    }
