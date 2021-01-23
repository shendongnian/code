    while (reader.Read())
    {
        ListaImenika.Items.Add(new DbItem {
            Ime = reader.GetString(1),
            Prezime = reader.GetString(2),
            Id = reader.GetInt32(0)
        });
    }
