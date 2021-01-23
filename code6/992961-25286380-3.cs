    private void sinc(object sender, EventArgs e)
    {
        if (iso.TryGetValue<string>("isoServer", out retornaNome))
        {
            serv = retornaNome;
        } 
        else 
        {
            // Let the user know.
            return;
        }
    
        order.Visibility = Visibility.Collapsed;
    
        client = new WebClient();
        url = serv + "/json.html";
        Uri uri = new Uri(url, UriKind.Absolute); // <<< Absolute instead of RelativeOrAbsolute
        client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
        client.OpenReadAsync(uri);
    }
   
