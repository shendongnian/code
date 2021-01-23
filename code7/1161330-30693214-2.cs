     private static readonly Regex cHttpUrlsRegex = new Regex(@"(?<url>((http|https):[/][/]|www.)([a-z]|[A-Z]|[0-9]|[_/.=&?%-]|[~])*)", RegexOptions.IgnoreCase);
    
            public static IEnumerable<string> ExtractHttpUrls(string aText, string aMatch = null)
            {
                if (String.IsNullOrEmpty(aText)) yield break;
                var matches = cHttpUrlsRegex.Matches(aText);
                var vMatcher = aMatch == null ? null : new Regex(aMatch);
                foreach (Match match in matches)
                {
                    var vUrl = HttpUtility.UrlDecode(match.Groups["url"].Value);
                    if (vMatcher == null || vMatcher.IsMatch(vUrl))
                        yield return vUrl;
                }
            }
    
    foreach (var link ExtractHttpUrls(s1))
                    {
                        count++;
                           if (link.StartsWith("http") && !listBox1.Items.Contains(link))
                               listBox1.Items.Add(link);
                    }
