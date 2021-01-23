            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Test;Persist Security Info=True;User ID=**;Password=*****"); 
            SqlCommand cmd = new SqlCommand("select * from Appointments where PersonID = '" + textBox4.Text + "'", con); 
            con.Open(); 
            SqlDataReader rdr = cmd.ExecuteReader();
            dt.Load(rdr);
            foreach (DataRow Dr in dt.Rows)
            {
                listBox1.Items.Add(Dr["COLUMNNAME"].ToString());
            }
            con.Close(); 
