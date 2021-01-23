    Is this Approach right ?
    
     HttpStreamContent streamContent = new HttpStreamContent(stream.AsInputStream());
     streamContent.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);
     streamContent.Headers.Add("Content-Length", stream.Length.ToString());
     streamContent.Headers.Add("Content-Disposition", "form-data; name=\"" + flKey +    "\"; filename=\"" + fleNm + "\"");
     Windows.Web.Http.HttpRequestMessage request = new     Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, uri);
     request.Content = streamContent;
     var httpClient = new Windows.Web.Http.HttpClient();
     var cts = new CancellationTokenSource();
     Windows.Web.Http.HttpResponseMessage response = await httpClient.SendRequestAsync(request).AsTask(cts.Token);
     String resp = response.ToString();
