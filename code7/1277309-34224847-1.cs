                HtmlAgilityPack.HtmlDocument htmlparsed = new HtmlAgilityPack.HtmlDocument();
                htmlParsed.LoadHtml(finalMessageContent[0]);
                List<HtmlNode> OrderedDivs = htmlParsed.DocumentNode.Descendants("div").
                Where(a => a.Attributes.Any(af => af.Value == "postedDate")).
                OrderByDescending(d => DateTime.Parse(d.InnerText)); //unsafe parsing
