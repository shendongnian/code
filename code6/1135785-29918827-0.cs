        private static string SanitizeUrl(string url)
        {
            var uri = new Uri(url);
            var path = uri.GetLeftPart(UriPartial.Path);
            path += path.EndsWith("/") ? "" : "/";
            var query = uri.ParseQueryString();
            var dict = new SortedDictionary<string, string>(query.AllKeys
                .Where(k => !string.IsNullOrWhiteSpace(query[k]))
                .ToDictionary(k => k, k => query[k]));
            return (path + ToQueryString(dict)).ToLower();
        }
        private static string ToQueryString(SortedDictionary<string, string> dict)
        {
            var items = new List<string>();
            foreach (var entry in dict)
            {
                items.Add(string.Concat(entry.Key, "=", Uri.EscapeUriString(entry.Value)));
            }
            return (items.Count > 0 ? "?" : "") + string.Join("&", items.ToArray());
        }
