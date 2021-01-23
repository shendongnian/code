    protected void GenerateXml(Dictionary<string, List<string>> imagesByUrl)
    {    
        XNamespace nsSitemap = "http://www.sitemaps.org/schemas/sitemap/0.9";
        XNamespace nsImage = "http://www.google.com/schemas/sitemap-image/1.1";
    
        var sitemap = new XDocument(new XDeclaration("1.0", "UTF-8", ""));
    
        var urlSet = new XElement(nsSitemap + "urlset",
            new XAttribute("xmlns", nsSitemap),
            new XAttribute(XNamespace.Xmlns + "image", nsImage),
            imagesByUrl.Select(entry => 
                new XElement(nsSitemap + "url",
                    new XElement(nsSitemap + "loc", entry.Key),
                    from urlNode in entry.Value
                    select new XElement(nsImage + "image",
                        new XElement(nsImage + "loc", urlNode)
                    )
            )
        );
        sitemap.Add(urlSet);
        var path = HttpContext.Current.Server.MapPath("/Static/sitemaps/Sitemap-image.xml");
        sitemap.Save(path);
    }
