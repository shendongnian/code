    byte[] concatinated = null;
    string boundary = string.Empty;
    boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
    byte[] buffer;
    StringBuilder sb = new StringBuilder();
    sb.Append("--" + boundary + "\r\n");
    foreach (KeyValuePair<string, string> param1 in kparams)
    {
        sb.Append("Content-Disposition: form-data; name=\"" + param1.Key + "\"" + "\r\n");
        sb.Append("\r\n");
        sb.Append(param1.Value);
        sb.Append("\r\n--" + boundary + "\r\n");
    }
    buffer = Encoding.UTF8.GetBytes(sb.ToString());
    byte[] fileBytes = null;
    byte[] filebytes2 = null;
    foreach (KeyValuePair<string, StorageFile> file in kfiles)
    {
        StorageFile storageFile = await Windows.Storage.StorageFile.GetFileFromPathAsync(file.Value.Path);
        using (IRandomAccessStreamWithContentType stream = await storageFile.OpenReadAsync())
        {
            fileBytes = new byte[stream.Size];
            using (DataReader reader = new DataReader(stream))
            {
                await reader.LoadAsync((uint)stream.Size);
                reader.ReadBytes(fileBytes);
            }
        }
        filebytes2 = BuildByteArray("fileData", storageFile.Name, fileBytes, boundary);
        concatinated = new byte[buffer.Length + filebytes2.Length];
        System.Buffer.BlockCopy(buffer, 0, concatinated, 0, buffer.Length);
        System.Buffer.BlockCopy(filebytes2, 0, concatinated, buffer.Length, filebytes2.Length);
        buffer = new byte[concatinated.Length];
        concatinated.CopyTo(buffer, 0);
    }
