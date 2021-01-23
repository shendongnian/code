    protected bool URLExists(string url, params int[] acceptableCodes)
    {
        Func<string, int> getStatusCode = pageUrl =>
        {
            var statusCode = -1; // Default value
            var webRequest = (HttpWebRequest)WebRequest.Create(pageUrl);
            webRequest.Timeout = 1200;
            webRequest.Method = "GET";
            //webRequest.AllowAutoRedirect = true;
            //webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.110 Safari/537.36";
            HttpWebResponse response = null;
            try
            {
                response = webRequest.GetResponse() as HttpWebResponse;
            }
            catch (WebException webException)
            {
                response = webException.Response as HttpWebResponse;
            }
            finally
            {
                if (response != null)
                {
                    statusCode = (int)response.StatusCode;
                    response.Dispose();
                }
            }
            return statusCode;
        };
        Func<int, bool> isStatusCodeOk = code =>
        {
            if (acceptableCodes != null && acceptableCodes.Contains(code))
            {
                // Accept this code
                return true;
            }
            if (code >= 100 && code < 400) //Good requests
            {
                return true;
            }
            if (code >= 500 && code <= 510) //Server Errors
            {
                return false;
            }
            // Default
            return false;
        };
        var result = false;
        try
        {
            var statusCode = getStatusCode(url);
            result = isStatusCodeOk(statusCode);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        return result;
    }
