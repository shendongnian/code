    protected override void OnActivated(IActivatedEventArgs args)
    {
        if (args.Kind == ActivationKind.Protocol)
        {
            var eventArgs = args as ProtocolActivatedEventArgs;
            if (eventArgs != null)
            {
                var uri = eventArgs.Uri;
                tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());
    
                // URI association launch for cameracapture.
                if (tempUri.Contains("cameracapture:CaptureImage?folder="))
                {
                    // Get the folder (after "folder=").
                    int folderIndex = tempUri.IndexOf("folder=") + 7;
                    string folder = tempUri.Substring(folderIndex);
    
                    // Do something with the request
                }
            }
        }
    }
