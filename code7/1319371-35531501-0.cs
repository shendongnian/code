    NpgSqlCommand cmd = new NpgsqlCommand("select resimismi, resimkendi from reismDatabase",
        conn);
    NpgsqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        string photoName = reader.GetString(0);
        Byte[] photoContents = (Byte[])Reader.GetValue(1);
        Image photo;
        if (photoContents != null)
        {
            using (Stream st = new System.IO.MemoryStream(photoContents))
                photo = Image.FromStream(st);
        }
    }
    reader.Close();
