            HttpContent stringStreamContent = new StringContent(json);
            stringStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpContent fileStreamContent = new StreamContent(fileStream);
            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            
            // Construct a MultiPart
            // 1st : JSON Object with IN parameters
            // 2nd : Octet Stream with file to upload
            var content = new MultipartContent("mixed");
            content.Add(stringStreamContent);
            content.Add(fileStreamContent);
            // POST the request as "multipart/mixed"
            var result = client.PostAsync(myUrl, content).Result;
