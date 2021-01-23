     public string UploadGameToWebsite(string filename, string url, string method = null)
        {
            var client = new HttpClient();
            var content = new MultipartFormDataContent();
            using (var fileStream = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                content.Add(new StreamContent(fileStream), "Game", "Game.txt");
                var task = client.PutAsync(url, content);
                var result = task.Result.ToString();            
                ereturn result;
            }
        }
