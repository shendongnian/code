    SQLiteDataReader reader = command.ExecuteReader();
    while (reader.Read())
    {
        using(var file = reader.GetStream(0))
        using(var unzip = new GZipStream(file, CompressionMode.Decompress))
        using(var fileReader = new StreamReader(unzip))
        {
            while(!fileReader.EndOfStream)
            {
                var line = fileReader.ReadLine();
            }
        }
    }
