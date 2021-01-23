    protected bool URLExists(string url, params int[] acceptableCodes)
    {
        Func<string, int> getStatusCode = pageUrl =>
        {
            var statusCode = -1; // Default status code
            var webRequest = (HttpWebRequest)WebRequest.Create(pageUrl);
            webRequest.Timeout = 1200;
            webRequest.Method = "GET";
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
                    response.Close();
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
        var statusCode = getStatusCode(url);
        return isStatusCodeOk(statusCode);
    }
