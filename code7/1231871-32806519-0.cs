    SqlCommand cmd1 = new SqlCommand(query, sc);
    using (SqlDataReader sdr = cmd1.ExecuteReader())
    {
        while (sdr.Read())
        {
            for (int i = 0; i < sdr.FieldCount; i++)
            {
                label23.text += sdr[i].ToString();
            }
        }
    }
    sc.Close();
