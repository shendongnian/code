    StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
    StorageFile file = null;
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(filepath);
    
    //TODO Systemuser
    request.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
    var response = await request.GetResponseAsync();
    List<Byte> allBytes = new List<byte>();
    using (Stream imageStream = response.GetResponseStream()) {
          byte[] buffer = new byte[4000];
          int bytesRead = 0;
          while ((bytesRead = await imageStream.ReadAsync(buffer, 0, 4000)) > 0) {
               allBytes.AddRange(buffer.Take(bytesRead));
          }
    }
    file = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
    await FileIO.WriteBytesAsync(file, allBytes.ToArray());
    await RenderPDFPage(fileName);
