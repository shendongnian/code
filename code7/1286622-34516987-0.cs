           SqlCommand cmd = new SqlCommand("select * from personeel where wachtwoord =" + textBox1.Text + "", conn);
           SqlDataReader dr = cmd.ExecuteReader();
         
            int count = 0;
            while(dr.Read())
            {
               count += 1;
            }
            if (count ==1)
            {
                SqlCommand cmd1 = new SqlCommand("select afdeling from personeel where wachtwoord =" + textBox1.Text + "", conn);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                MessageBox.Show("OK");
                if (dr1.Rows[0][0].ToString() == "keuken")
                {
                    this.Hide();
                    keukenoverzicht keukenoverzicht = new keukenoverzicht();
                    keukenoverzicht.Show();
                }
                else if (dr1.Rows[0][0].ToString() == "bar")
                {
                    this.Hide();
                    baroverzicht baroverzicht = new baroverzicht();
                    baroverzicht.Show();
                }
                else
                {
                    this.Hide();
                    tafeloverzicht tafeloverzicht = new tafeloverzicht();
                    tafeloverzicht.Show();
                }   
            }
            else
            {
                MessageBox.Show("wachtwoord niet corect");
            }
            textBox1.Clear();
            conn.Close();
        }
    }
