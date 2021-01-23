    client = new WebClient();
    url = serverName + "/json.html";
    Uri uri = new Uri(url, UriKind.Absolute); // <<< Absolute instead of RelativeOrAbsolute
    client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
    client.OpenReadAsync(uri);
