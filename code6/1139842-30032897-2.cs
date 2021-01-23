    private void button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = "Data Source=asa-PC\\SQLEXPRESS;Initial Catalog=table1;Integrated Security=True";
            con.Open();
            using (SqlCommand cmd = new SqlCommand("select * from worker where number=@Number", con))
            {
                cmd.Parameters.AddWithValue("@Number", textBox1.Text);//or explicity specify type using .Add
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //Add to List<Worker> with properties Name and Number etc
                            textBox2.Text = dr[0].ToString();
                            textBox3.Text = dr[1].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No record is found with this number >> " + textBox1.Text.ToString());
                    }
                }
            }
        }
    }
