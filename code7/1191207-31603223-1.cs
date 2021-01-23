    using (var conn = /* create connection */)
    {
        conn.Open();
        using (var command = conn.CreateCommand())
        {
            command.CommandText = "[Query text from above]";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    favsongs.Add(new Song
                    {
                        _id = sdr1.GetString(1),
                        title = Crypto_Engine.Decrypt(sdr1.GetString(2), "songcord-ekbana-crypto11"),
                        isTabs = sdr1.GetString(3)
                    });            
                }
            }
        }
        this.FavSongs = favsongs.OrderBy(s=> s.title).ToList();
    }
