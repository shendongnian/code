    using (Stream stream = new MemoryStream(bytes))
    {
        try
        {
            //await _client.Context.ExecuteAsync(uri, "POST", stream);
            await _client.Files.AddAsync(fileName, true, stream);
        }
        catch (InvalidOperationException exception)
        { MessageBox.Show(exception.Message); }
    }
