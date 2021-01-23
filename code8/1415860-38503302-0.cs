    sqlCmd.CommandText = "SELECT Naziv, Sifra From Zupanije";
    conn.Open();
    using (var zupanijeReader = sqlCmd.ExecuteReader())
    {
        while (zupanijeReader.Read())
        {
            izborZupanija.Add(zupanijeReader.GetString(0), zupanijeReader.GetDouble(1));
        }
    }
    conn.Close();
