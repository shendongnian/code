    class AssociationUriMapper : UriMapperBase
        {
            private string tempUri;
    
            public override Uri MapUri(Uri uri)
            {
                tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());
    
                // URI association launch for cameracapture.
                if (tempUri.Contains("cameracapture:CaptureImage?folder="))
                {
                    // Get the folder (after "folder=").
                    int folderIndex = tempUri.IndexOf("folder=") + 7;
                    string folder = tempUri.Substring(folderIndex);
    
                    // Map the capture image request to CaptureImage.xaml
                    return new Uri("/CaptureImage.xaml?folder=" + folder, UriKind.Relative);
                }
    
                // Otherwise perform normal launch.
                return uri;
                }
            }
