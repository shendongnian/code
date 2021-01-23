    public string HtmlAgilityPackPopulateAltWithSrcIfEmpty(string html)
        {
            HtmlAgilityPack.HtmlDocument hap;
            Uri uriResult;
            if (Uri.TryCreate(html, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp)
            { // html is a URL 
                var doc = new HtmlAgilityPack.HtmlWeb();
                hap = doc.Load(uriResult.AbsoluteUri);
            }
            else
            { // html is a string
                hap = new HtmlAgilityPack.HtmlDocument();
                hap.LoadHtml(html);
            }
            var nodes = hap.DocumentNode.SelectNodes("//img[string-length(@alt) = 0]");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var val = node.GetAttributeValue("src", string.Empty);
                    if (val.ToUpper().EndsWith(".JPG"))
                        node.SetAttributeValue("alt", val.Substring(0, val.Length - 4));
                }
            }
            var ffg = hap.DocumentNode.OuterHtml;
            return hap.DocumentNode.OuterHtml;
        }
