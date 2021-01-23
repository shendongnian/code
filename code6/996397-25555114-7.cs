    public static async Task<byte[]> DownloadFile(Uri webUri,string userName,string password, string relativeFileUrl, CancellationToken ct, TimeSpan? timeout = null)
    {
            try
            {
                var securePassword = new SecureString();
                foreach (var c in password)
                {
                    securePassword.AppendChar(c);
                }
                var credentials = new SharePointOnlineCredentials(userName, securePassword);
                var authCookie = credentials.GetAuthenticationCookie(webUri);
                var fedAuthString = authCookie.TrimStart("SPOIDCRL=".ToCharArray());
                var cookieContainer = new CookieContainer();
                cookieContainer.Add(webUri, new Cookie("SPOIDCRL", fedAuthString));
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = cookieContainer;
                
                HttpClient _client = new HttpClient(handler);
                if (timeout.HasValue)
                    _client.Timeout = timeout.Value;
                ct.ThrowIfCancellationRequested();
                var fileUrl = new Uri(webUri, relativeFileUrl);
                var resp = await _client.GetAsync(fileUrl);
                var result = await resp.Content.ReadAsByteArrayAsync();
                if (!resp.IsSuccessStatusCode)
                    return null;
                return result;
            }
            catch (Exception) { return null; }
     }
 
