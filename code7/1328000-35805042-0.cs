     protected void Button1_Click (object sender, EventArgs e)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into service_type (type) values('"+TextBox1.Text+"')";
    
                cmd.ExecuteNonQuery();
                con.Close();
            }
