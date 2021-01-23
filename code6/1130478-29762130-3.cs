      // incorrect - appends xmlns=""
      if (x.DocumentElement != null) {
        var sitemap = x.CreateElement("sitemap");
        var xloc = x.CreateElement("loc");
        xloc.InnerText = "Hello";
        sitemap.AppendChild(xloc);
        var lastmod = x.CreateElement("lastmod"); 
        lastmod.InnerText = DateTime.Now.ToShortDateString();
        sitemap.AppendChild(lastmod);
        x.DocumentElement.AppendChild(sitemap);
      }
      Console.WriteLine(x.InnerXml);
