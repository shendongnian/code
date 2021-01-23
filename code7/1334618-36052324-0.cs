    var oneDriveClient = await OneDriveClientExtensions.GetAuthenticatedUniversalClient(new[] { "wl.signin", "onedrive.readwrite" });
    
    var filter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
    filter.CacheControl.ReadBehavior = Windows.Web.Http.Filters.HttpCacheReadBehavior.MostRecent;
    filter.CacheControl.WriteBehavior = Windows.Web.Http.Filters.HttpCacheWriteBehavior.NoCache;
    
    var httpClient = new HttpClient(filter);
    
    var request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.onedrive.com/v1.0/drive/special/approot"));
    request.Headers.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue("Bearer", oneDriveClient.AuthenticationProvider.CurrentAccountSession.AccessToken);
    
    var response = await httpClient.SendRequestAsync(request);
    
    var item = oneDriveClient.HttpProvider.Serializer.DeserializeObject<Item>(await response.Content.ReadAsStringAsync());
    System.Diagnostics.Debug.WriteLine($"{item.Name}'s size is {item.Size}");
