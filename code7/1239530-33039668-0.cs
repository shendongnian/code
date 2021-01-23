    XmlTextWriter writer = new XmlTextWriter("product.xml", System.Text.Encoding.UTF8);
    writer.WriteStartDocument(true);
    writer.WriteComment("This sitemap was created using the free tool found here: http://www.auditmypc.com/free-sitemap-generator.asp");
    writer.Formatting = Formatting.Indented;
    writer.Indentation = 2;
    writer.WriteStartElement("urlset");
