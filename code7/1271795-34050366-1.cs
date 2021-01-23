    var wi = (WindowsIdentity)HttpContext.User.Identity;
    
    var wic = wi.Impersonate();
    
     using (var client = new WebClient { UseDefaultCredentials = true })
        {
            client.DownloadStringAsync(url);
        }
    wic.Undo();
