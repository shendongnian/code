    public void Sample()
    {
        string name = comboBox1.Text;
        query = "select * from Record Where Name= @Name";
        cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Name", name);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                textBox1.Text = (dr["Items1"].ToString());
                textBox2.Text = (dr["Items1_Charge"].ToString());
                textBox3.Text = (dr["Items2"].ToString());
                textBox4.Text = (dr["Items2_Charge"].ToString());
                textBox5.Text = (dr["Items3"].ToString());
                textBox6.Text = (dr["Items3_Charge"].ToString());
                textBox7.Text = (dr["Items4"].ToString());
                textBox8.Text = (dr["Items4_Charge"].ToString());
            }
        }
    }
