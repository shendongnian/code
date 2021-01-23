       HttpContent fileContent = new ByteArrayContent(File.ReadAllBytes(filePath)
       string mimeType = System.Web.MimeMapping.GetMimeMapping(fileName);
       
       //specifying MIME Type
       fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mimeType);
        content.Add(fileContent, "file",fileName);
            
        var result = client.PostAsync(postUrl, content).Result;
