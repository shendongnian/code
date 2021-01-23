    private void btn_Click(object sender, RoutedEventArgs e)
    {
        SqlConnection con = new SqlConnection("server = localhost; database= test;Integrated Security = true;MultipleActiveResultSets=True;");
    
        con.Open();
    
        SqlCommand cmd = new SqlCommand("select id, name, quantity from so where name like '%" + txt.Text + "%'", con);
        SqlDataReader rd = cmd.ExecuteReader();
    
        while (rd.Read())
        {
            if (Convert.ToInt32(rd["quantity"]) > 0)
            {
    
                cmd.CommandText = "Update so set quantity =quantity - 1  where name Like '%' + @name + '%'";
                cmd.Parameters.AddWithValue("@name", txt.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
    
                MessageBox.Show("sorry!");
            }
        }
         
        rd.Close();
        con.Close();
    } 
