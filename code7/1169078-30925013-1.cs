        public static HttpRequestMessage Clone(this HttpRequestMessage req, string newUri)
        {
            HttpRequestMessage clone = new HttpRequestMessage(req.Method, newUri);
            if (req.Method != HttpMethod.Get)
            {
                clone.Content = req.Content;
            }
            clone.Version = req.Version;
            foreach (KeyValuePair<string, object> prop in req.Properties)
            {
                clone.Properties.Add(prop);
            }
            foreach (KeyValuePair<string, IEnumerable<string>> header in req.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            clone.Headers.Host = new Uri(newUri).Authority;
            return clone;
        }
