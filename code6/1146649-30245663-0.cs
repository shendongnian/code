                        string url = "http://your.sharepoint.site";
                        client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }); 
                        client.BaseAddress = new System.Uri(url);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                        client.DefaultRequestHeaders.Add("X-RequestDigest", digest);
                        client.DefaultRequestHeaders.Add("X-HTTP-Method", "POST");
                        client.DefaultRequestHeaders.Add("binaryStringRequestBody", "true");
                        ByteArrayContent file = new ByteArrayContent(fileBytes);
                        HttpResponseMessage response = await client.PostAsync(String.Concat("_api/web/lists/getByTitle('Images')/RootFolder/Files/add(url='", filename, ".jpg',overwrite='true')?$expand=ListItemAllFields"), file);
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {}
