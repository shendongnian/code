      if (x.DocumentElement != null) {
        var xmlns = (x.DocumentElement.NamespaceURI);
        var sitemap = x.CreateElement("sitemap", xmlns);
        var xloc = x.CreateElement("loc", xmlns);
        xloc.InnerText = "Hello";
        sitemap.AppendChild(xloc);
        var lastmod = x.CreateElement("lastmod", xmlns);
        lastmod.InnerText = DateTime.Now.ToShortDateString();
        sitemap.AppendChild(lastmod);
        x.DocumentElement.AppendChild(sitemap);
      }
      Console.WriteLine(x.InnerXml);
