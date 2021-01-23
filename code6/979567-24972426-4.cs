    public static class TokenValidator
    {
        /// <summary>
        /// Obtém um novo access token na API do google.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public static GoogleRefreshTokenModel ValidateGoogleToken(string clientId, string clientSecret, string refreshToken)
        {
            const string url = "https://accounts.google.com/o/oauth2/token";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", refreshToken)
            };
            var content = GetContentAsync(url, "POST",  parameters);
            var token = JsonConvert.DeserializeObject<GoogleRefreshTokenModel>(content);
            return token;
        }
        private static string GetContentAsync(string url, 
            string method = "POST",
            IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            return method == "POST" ? PostAsync(url, parameters) : GetAsync(url, parameters);
        }
        private static string PostAsync(string url, IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            var uri = new Uri(url);
            var request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";
            var postParameters = GetPostParameters(parameters);
            var bs = Encoding.UTF8.GetBytes(postParameters);
            using (var reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (var response = request.GetResponse())
            {
                var sr = new StreamReader(response.GetResponseStream());
                var jsonResponse = sr.ReadToEnd();
                sr.Close();
                return jsonResponse;
            }
        }
        private static string GetPostParameters(IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            var postParameters = string.Empty;
            foreach (var parameter in parameters)
            {
                postParameters += string.Format("&{0}={1}", parameter.Key,
                    HttpUtility.HtmlEncode(parameter.Value));
            }
            postParameters = postParameters.Substring(1);
            return postParameters;
        }
        private static string GetAsync(string url, IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            url += "?" + GetQueryStringParameters(parameters);
            var forIdsWebRequest = WebRequest.Create(url);
            using (var response = (HttpWebResponse)forIdsWebRequest.GetResponse())
            {
                using (var data = response.GetResponseStream())
                using (var reader = new StreamReader(data))
                {
                    var jsonResponse = reader.ReadToEnd();
                    return jsonResponse;
                }
            }
        }
        private static string GetQueryStringParameters(IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            var queryStringParameters = string.Empty;
            foreach (var parameter in parameters)
            {
                queryStringParameters += string.Format("&{0}={1}", parameter.Key,
                    HttpUtility.HtmlEncode(parameter.Value));
            }
            queryStringParameters = queryStringParameters.Substring(1);
            return queryStringParameters;
        }
    }
