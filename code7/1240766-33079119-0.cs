    public List<string> HtmlAgilityPackGetNumericSpan4to10(string html)
    {
            var vals = new List<string>();
            HtmlAgilityPack.HtmlDocument hap;
            Uri uriResult;
            if (Uri.TryCreate(html, UriKind.Absolute, out uriResult) 
                                && uriResult.Scheme == Uri.UriSchemeHttp)
            { // html is a URL 
                var doc = new HtmlAgilityPack.HtmlWeb();
                hap = doc.Load(uriResult.AbsoluteUri);
            }
            else
            { // html is a string
                hap = new HtmlAgilityPack.HtmlDocument();
                hap.LoadHtml(html);
            }
            var nodes = hap.DocumentNode.SelectNodes("//span[@class='num']");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var val = node.InnerText;
                    if (val.ToCharArray().All(p => Char.IsDigit(p)) 
                                     && val.Length >= 4 && val.Length <= 10)
                        vals.Add(val);
                }
            }
            return vals;
    }
