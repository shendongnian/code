    foreach (SitemapNodeAlternate a in alternate)
    {             
        MyWriter.WriteStartElement("xhtml", "link", null);
        MyWriter.WriteAttributeString("rel", "alternate");
        MyWriter.WriteAttributeString("href", a.href);
        MyWriter.WriteAttributeString("hreflang", a.hreflang);               
        MyWriter.WriteEndElement();
    }
