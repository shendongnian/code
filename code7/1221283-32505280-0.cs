    NpgsqlCommand cmd;
    [OnTextboxUpdate]
    {
     cmd=new NpgsqlCommand("SELECT * FROM identification; SELECT * FROM height; SELECT * FROM weight; SELECT * FROM bloodpressure  WHERE eid like '" + textBox1.Text + "%'", conn);
     updateGUI();
    }
   
    [updateGUI]
    {
       using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {       
                    textBox3.Text = (dr["lastname"].ToString());
                    textBox4.Text = (dr["firstname"].ToString());
                    textBox2.Text = (dr["middlename"].ToString());
                    textBox9.Text = (dr["sex"].ToString());
                    textBox5.Text = (dr["birthdate"].ToString());
                    textBox6.Text = (dr["age"].ToString());
                    textBox10.Text = (dr["department"].ToString());
                    textBox7.Text = (dr["address"].ToString());
                    textBox11.Text = (dr["status"].ToString());
                    textBox8.Text = (dr["contact"].ToString());
                }
                if (dr.NextResult())
                {
                    while (dr.Read())
                    {
                        textBox12.Text = (dr["height"].ToString());
                    }
                }
                if (dr.NextResult())
                {
                    while (dr.Read())
                    {
                        textBox15.Text = (dr["weight"].ToString());
                    }
                }
                if (dr.NextResult())
                {
                    while (dr.Read())
                    {
                        textBox16.Text = (dr["systole"].ToString());
                        textBox17.Text = (dr["diastole"].ToString());
                    }
                }
     }
     
