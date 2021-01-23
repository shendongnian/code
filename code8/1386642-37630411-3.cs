    Task<Response> MyNotificationPost(Uri uri, byte[] bodyData)
    {
        ServicePointManager.Expect100Continue = false;
        HttpWebRequest request = WebRequest.CreateHttp(uri);
        request.Method = "POST";
        request.Headers["Accept"] = "application/json";
        request.Headers["Authorization"] = "key=" + API_KEY;
        return Task.Factory.FromAsync<Stream>(
            request.BeginGetRequestStream, 
            request.EndGetRequestStream, 
            null).ContinueWith(
                reqStreamTask => 
                {
					using (reqStreamTask.Result) 
                    {
						reqStreamTask.Result.Write(bodyData, 0, bodyData.Length);
					}
							
					return Task.Factory.FromAsync<WebResponse> (
                        request.BeginGetResponse, 
                        request.EndGetResponse, 
                        null).ContinueWith(
                            resTask => 
                            {
                                return new Response((HttpWebResponse)resTask.Result);
                            }, 
                            cancellationToken);
				}, 
                cancellationToken).Unwrap();
    }
