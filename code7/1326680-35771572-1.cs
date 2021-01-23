     private void button1_Click(object sender, EventArgs e)
            {
               string Constring = ConnectionString.Constring;
               SqlConnection con = new SqlConnection(Constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("select usname,pwd from regis where usname='" + textBox1.Text + "'", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                     usname = dr["usname"].ToString();
                     pwd = dr["pwd"].ToString();
                }
                            dr.Close();
                con.Close();
                if (textBox1.Text == usname && textBox2.Text == pwd)
                {
                    this.Hide();
                    UserHome us = new UserHome(textBox1.Text);
                    us.Show();
                }
                else
                {
                    MessageBox.Show("Invalid USername or Password");
                }
    
            }
