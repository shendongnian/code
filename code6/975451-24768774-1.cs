    string connString = @"database=Agenda_db; Data Source=Marian-PC\SQLEXPRESS; Persist Security Info=false; Integrated Security=SSPI";
    using (SqlConnection conn = new SqlConnection(connString))
    {
        try
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Contact", conn))
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBox1.Items.Add(rdr[0].ToString() + " " + rdr[1].ToString() + " " + rdr[2].ToString());
                }
            }
            using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM Numar_contact", conn))
            using (SqlDataReader rdr2 = cmd.ExecuteReader())
            {
                while (rdr2.Read())
                {
                    listBox1.Items.Add(rdr2[0].ToString() + " " + rdr2[1].ToString());
                }
            }
        }
        catch { }
    }
