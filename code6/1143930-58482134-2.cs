        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection (@"Data SOURCE=.\SQLEXPRESS;AttachDbFilename=C:\Users\itmaint\source\repos\database\database\G-data.mdf;Integrated Se[a.][2]curity=True;Connection Timeout=30;User Instance=True");
            string query ="Select * From Login Where Username='" + textBox1.Text.Trim() + "' and Password ='" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Form2 ss = new Form2();
                this.Hide();
                ss.Show();
            }
          
  
