    public async Task<Image> GetImageAsync(string url)
        {
            var tcs = new TaskCompletionSource<Image>();
            try
            {
                Image webImage = null;
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.Method = "GET";
                await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null)
                    .ContinueWith(task =>
                    {
                        var webResponse = (HttpWebResponse) task.Result;
                        Stream responseStream = webResponse.GetResponseStream();
                        if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                            responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                        else if (webResponse.ContentEncoding.ToLower().Contains("deflate"))
                            responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
                        if (responseStream != null) webImage = Image.FromStream(responseStream);
                        tcs.TrySetResult(webImage);
                        webResponse.Close();
                        responseStream.Close();
                    });
            }
            catch (Exception)
            {
                //
            }
            return tcs.Task.Result;
        }
