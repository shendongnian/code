    public byte[] GetFileContent(File file)
    {
        var request = System.Net.HttpWebRequest
            .Create($"{_serviceDefinition.ServiceId}/_api/Web/getfilebyserverrelativeurl('{file.ServerRelativeUrl}')/$value");
    
        request.Headers.Add(System.Net.HttpRequestHeader.Authorization, $"Bearer {GetAccessToken()}");
    
        byte[] fileData = new byte[0];
    
        using (var sr = request.GetResponse().GetResponseStream())
        {
            using (var ms = new System.IO.MemoryStream())
            {
                byte[] buffer = new byte[0x1000];
                int bytes;
                while ((bytes = sr.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, bytes);
                }
    
                fileData = ms.ToArray();
            }
        }
    
        return fileData;
    }
