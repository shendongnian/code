    var httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Add("X-Auth-Token", auth_token);
    var bytes = new ByteArrayContent(file);
    var formData = new MultipartFormDataContent();
    formData.Add(bytes, internalFileName, internalFileName);
    // this creates a checksum to send over for verification of non corrupted transfers
    // this is also prevents us from using RestSharp due to its inability to create a checksum of the request body prior to sending
    var md5Checksum = BitConverter.ToString(MD5.Create().ComputeHash(formData.ReadAsByteArrayAsync().Result)).Replace("-", string.Empty).ToLower();
    httpClient.DefaultRequestHeaders.Add("ETag", md5Checksum);
            
    var url = string.Format("{0}/{1}{2}/{3}", storage_url, containerName, folderId, internalFileName);
    var resp = httpClient.PutAsync(url, formData).Result;
    httpClient.Dispose();
