    string[] x = new string[100];
            string[] y = new string[100];
            string[] z = new string[100];
            string[] den = new string[100];
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\DBSistem.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Denumire FROM Caracteristici", con);
            SqlCommand cmd1 = new SqlCommand("SELECT Valoare FROM Valori", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            int i = 0;
            while (sdr.Read())
            {
                    x[i] = sdr.GetString(0);
                    i++;
            }
            sdr.Close();
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            i = 0;
            while(sdr1.Read())
            {
                y[i] = sdr1.GetString(0);
                i++;
            }
            sdr1.Close();
            i = 0;
            SqlCommand cmd2 = new SqlCommand("SELECT UM From Caracteristici", con);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            while (sdr2.Read())
            {
                z[i] = sdr2.GetString(0);
                i++;
            }
            sdr2.Close();
            for (i = 0; i <= 10; i++)
            {
                string[] RowData = { x[i], y[i], z[i] };
                dataGridView2.Rows.Add(RowData);
            }
