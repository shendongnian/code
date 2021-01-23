    public static Image favicon(string u, string file)
    {
        if (!String.IsNullOrEmpty(u) && !u.Contains("blank"))
        {
            // Check if this is a valid URL
            if (Uri.IsWellFormedUriString(u, UriKind.Absolute))
            {
                // Create the favicon.ico URL
                var url = new Uri(u);
                var iconUrl = $"http://{url.Host}/favicon.ico";
    
                // Try and download the icon
                var client = new WebClient();
                try
                {
                    return Image.FromStream(client.OpenRead(iconUrl));
                }
                catch (WebException)
                {
                    // If there was an error download the favicon, just return the file
                    return Image.FromFile(file);
                }
            }
            else
            {
                throw new ArgumentException("Parameter 'u' is not a valid URL");
            }
        }
        else
        {
            return Image.FromFile(file);
        }
    }
