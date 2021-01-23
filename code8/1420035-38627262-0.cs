      string TAT = string.Empty; 
      while (rdr2.Read())
            {
                 TAT = rdr["TAT"].ToString();
            }
            con220.Close();
            MessageBox.Show(TAT);
