    while (innerReader.Read())
    {
        var playlistMsg = new PlaylistMessageBindingModel();
        playlistMsg.Duration = reader.GetDecimal["size_time"];
    }
